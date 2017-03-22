/*Powered by Mohammad Reza Tayyebi
Email:tayyebimohammadreza@gmail.com
Page:https://Plus.Google.com/+MohammadRezaTayyebi
*/
function s_basic(c, a, b) { this.go = function (d) { b.find("ul").stop(true).animate({ left: (d ? -d + "00%" : (/Safari/.test(navigator.userAgent) ? "0%" : 0)) }, c.duration, "easeInOutExpo"); return d } };
jQuery("#slider-container").slider({ effect: "basic", prev: "", next: "", duration: 20 * 100, delay: 99 * 100, width: 640, height: 360, autoPlay: true, playPause: false, stopOnHover: true, loop: true, bullets: false, caption: true, captionEffect: "move", controls: true, onBeforeStep: 0 });