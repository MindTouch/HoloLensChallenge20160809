/* MIT License
*
* Copyright (c) 2016 MindTouch Inc.
*
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.VR.WSA;
using UnityEngine.VR.WSA.Input;
using UnityEngine.Windows.Speech;

public class SceneBehavior : MonoBehaviour {

    //--- Fields ---
    private SpatialMappingRenderer _renderer;
    private GestureRecognizer _gestureRecognizer;
    private KeywordRecognizer _keywordRecognizer;
    private GameObject _focusedObject;

    //--- Methods ---
    public void Start() {
        _renderer = GetComponent<SpatialMappingRenderer>();

        // initialize gesture recognizer
        _gestureRecognizer = new GestureRecognizer();
        _gestureRecognizer.TappedEvent += (source, count, ray) => {
            if(_focusedObject != null) {
                _focusedObject.SendMessage("OnTapGesture");
            }
        };
        _gestureRecognizer.StartCapturingGestures();

        // initialize keyword recognizer
        var keywords = new Dictionary<string, Action> {
            { "Reset", () => BroadcastMessage("OnResetVoiceCommand") },
            { "Hide", () => BroadcastMessage("OnHideVoiceCommand") },
            { "Show", () => BroadcastMessage("OnShowVoiceCommand") },
        };
        _keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        _keywordRecognizer.OnPhraseRecognized += args => {
            Action action;
            if(keywords.TryGetValue(args.text, out action)) {
                action.Invoke();
            }
        };
        _keywordRecognizer.Start();
    }

    public void Update() {
        var previousFocusedObject = _focusedObject;

        // do a raycast into the world based on the user's head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;
        RaycastHit hitInfo;
        _focusedObject = Physics.Raycast(headPosition, gazeDirection, out hitInfo) ? hitInfo.collider.gameObject : null;

        // restart gesture recognizer
        if(previousFocusedObject != _focusedObject) {
            _gestureRecognizer.CancelGestures();
            _gestureRecognizer.StartCapturingGestures();
        }
    }

    public void OnHideVoiceCommand() {
        _renderer.currentRenderSetting = SpatialMappingRenderer.RenderSetting.Occlusion;
    }

    public void OnShowVoiceCommand() {
        _renderer.currentRenderSetting = SpatialMappingRenderer.RenderSetting.CustomMaterial;
    }
}
