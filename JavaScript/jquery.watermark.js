// Copyright 2009 Josh Close
// This file is a part of jquery.watermark and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
/// <reference path="jquery-1.3.2.js" />
 
(function($) {
	var defaultOptions = {
		cssClass: "",
		onBeforeSetWatermark: null,
		onAfterSetWatermark: null,
		onBeforeRemoveWatermark: null,
		onAfterRemoveWatermark: null
	};
 
	jQuery.fn.watermark = function(watermarkText, options) {
		$(this).each(function() {
			if (this.type == "text" || this.type == "textarea") {
				initialize.call(this);
			}
		});
 
		function initialize() {
			setOptions.call(this);
			setEvents.call(this);
			var text = $.trim($(this).val());
			if (text.length == 0 || text == watermarkText) {
				setWatermark.call(this);
			}
		}
 
		function elementFocus(event) {
			var text = $.trim($(this).val());
			if (text.length == 0 || text == watermarkText) {
				removeWatermark.call(this);
			}
		}
 
		function elementBlur(event) {
			var text = $.trim($(this).val());
			if (text.length == 0 || text == watermarkText) {
				setWatermark.call(this);
			}
		}
 
		function setWatermark() {
			callEvent.call(this, options.onBeforeSetWatermark);
 
			$(this).addClass(options.cssClass).val(watermarkText);
 
			callEvent.call(this, options.onAfterSetWatermark);
		}
 
		function removeWatermark() {
			callEvent.call(this, options.onBeforeRemoveWatermark);
 
			$(this).removeClass(options.cssClass).val("");
 
			callEvent.call(this, options.onAfterRemoveWatermark);
		}
 
		function callEvent(event) {
			if (typeof (event) == "function") {
				event.call(this);
			}
		}
 
		function setEvents() {
			var el = $(this);
			el.focus(elementFocus);
			el.blur(elementBlur);
		}
 
		function setOptions() {
			el = $(this);
			options = $.extend({}, defaultOptions, el.data("watermark:options"), options);
			el.data("watermark:options", options);
		}
 
		return this;
	};
})(jQuery);
