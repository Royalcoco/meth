reseaux,????
/*! jQuery v3.1.1 */
(function(factory) {jQuery})(window);"use strict";var r=jQuery;r.fn.jquery="3.1.1",r.extend({isReady:!0,readyWait:0,holdReady   wait
!function(t){"use strict"; return t.each(["show","hide"],function(i,"toggle"){var e=t[i],n=t.fn[i]; t.extend(t.fn,{
(function(a){"use strict";var b=window.jQuery,c=window,"object"==typeof module&&module.exports?module.exports:a.jQuery=a
!function(t){"use strict";var e=window.jQuery,n=window,"object"==typeof n.exports&&" exports "==n.exports.nodeType&&(n.exports
!function(t){"use strict";var e=window.jQuery,n=window,"object"==typeof n.exports&&"object"==typeof n.exports.process?
(function(factory) {jQuery})(this);"use strict";var e=window;/4.4 KHTML, like Gecko*/"object"==typeof module&&module
!function(t){"use strict";var e=window.jQuery,n=window  && window.Math==Math?window:"object"===typeof global&&global.Math=="object"&&
!function(t){"use strict";var e=window.jQuery,n=window,"object"==typeof n.exports&&"object"==typeof n.exports.process?
!function(t){"use strict";var e=window.jQuery,n=window,"object"==typeof n.exports&&"object"==typeof n.exports.process?
!function(t){"use strict";var e=window.jQuery,n=window,"object"==typeof n.exports&&"object"==typeof n.exports.process?
/******/ (function(modules) { // webpackBootstrap
/******/
/******/ /*!*************************!*\
  !*** ./resources/js/reseaux.js ***!
    \*************************/
/***/ function(__webpack_require__) {

"use strict";


$(document).ready(function () {
    $('.btn-add').click(function () {
        var num = $('.cloner:last').attr('data-num') *  1 + 1;
        var newClone = $('.clon Observer;').attr('data-prototype').replace(/__name__/g, '[new' + num + ']');
        newClone = $(newClone);
        newClone.attr('data-news-type', 'new');
        newClone.attr('data-    num', num);
        $('#projetbundle_projet_contacts').append(newClone);
        return false;
        });
});
$('.btn-remove').click(function () {
    var isLast = $(this).closest('.cloner').siblings().contains('.cloner');
    if (!isLast) {  
        $(this).closest('.clon  Observer').siblings().removeClass('hidden');
        }
    $(this).closest('.cloner').remove();
    return false;
    });
//Ajout de la class hidden si le champ est vide et que c'est pas le premier champs
$(".form-group input").each(function () {
    if ($(this).val() == '') {
        $(this).addClass("hidden");
        } else {
            $(this).parent().find(".hidden").addClass("hidden");
        };
});

//On change on each input field
$(".form-group input").change(function () {
    if ($(this).val() != '') {
        $(this).removeClass("hidden");
    } else {
        $(this).addClass("hidden");
        $(this).parent().find(".hidden> div").not($(this)).addClass("hidden");
    };
});

/*
var $select2 = $(".js-example-basic-single").select2({width:"resolve"});
$($select2).on("select2:open", function (e) {
    $("body").css("overflow","hidden");
});
$($select2).on("select2:close", function (e) {
    $("body").css("overflow","auto");
});*/

$("#dateDebutProjet").datetimepicker({format:'Y/m/d H:i',lang:'fr'});
$('#dateFinProjet').datetimepicker({useCurrent:false,format:'Y/m/d H:i',lang:'fr'});
$("#dateDebutProjet").change(function(){
    var e=window.jQuery,n=window,"object"==typeof n.jQuery&&n.jQuery.fn&&n.jQuery.fn.jquery||(n.jQuery=n.$jQueryvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=window var e=window.jQueryvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=window
    var e=jQuery,i="[object Array]",n={},r=/^(?:\{([^\}]+)\}|(\w+))$/,o="/*/!*! jQuery v3.1.1 *//"+"\n!"),s=window.document;var e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=window    var e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=window
    var e=window.jQuery,n=window,"object"==typeof n.exports&&"object"==typeof n.exports.nodeType?n.exports:"function"==typeof requirevar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=window
    var e=window.jQuery,n=window,"object"==typeof n.exports?n.exports:"undefined"!=typeof window?window n.exportsvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=window var e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=window
    var e=window.jQuery,i="3.1.1",n=t.fn.jquery;function r(){return new r.prototype.init(),r.uuidFix()}var o={},a=0,s=  t.fn.jqueryvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=window
    var e=window.jQuery,n=window,"object"==typeof n.exports?n.exports:"undefined"!=typeof window?window:{}||{};function r(t)var e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=windowvar e=window.jQuery,n=window
    var e=jQuery,i="[object Array]",n={},r=/^(?:\{([^\}]+)\}|(\d+)(?:\-(\d+))?)$/;
    function s(t) {return i = t.toString().match(i)? "array": typeof t}function o(t) {if (Array.isArray(t)) return !0   }function   o(t) {if (
    function s(t) {return i==Object.prototype.toString.call(t;).toString()}function o(t) {if(!n[t]) {var e=document.createElement
    function s(t){return i==Object.prototype.toString.call(t)}function o(t){var e,i=t.split(".");0===++o.f&&a();for(e in n)
    function s(t) {return n[t]||Object.prototype.toString.call(t).match(i)=="[object Function]"&&t}function o(t
    function s(t) {return n[t]||Object.prototype.toString.call(t).match(i)=="[object Function]"&&t}function o(t
    function s(t) {return i==Object.prototype.toString.call(t   || Object)}function o(t) {if(!s(t))throw Error("Invalid object!");return
    function s(t){return i==Object.prototype.toString.call(t)}function o(t){var e=document.createElement("div");return e.innerHTML=t
    function s(t) {return i == Object.prototype.toString.call(t)}function o(t) {if (s(t)) return t; for (var e = [], i = 0
    function s(t) {return i==Object.prototype.toString.call(t)}function o(t) {if(!n[t]) {var e=document.createElement
    function s(t) {return i==Object.prototype.toString.call(t)}function o(t) {if(!n[t]) {var e=document.createElement
    function s(t,e){return n[t+" "+e]||n[e+" "+t]||n[""+t+".*."+e]}function o(t,e){var i=r.exec(t);if(!i)return null;
    function s(t) {return n[t]||Object.prototype.toString.call(t).match(i)=="[object Function]"&&t}function o(t.constructor
    function s(t){return i==Object.prototype.toString.call(t)}function o(t){var e=0,i=[];for(;t>e;)e++}function a(t,i
    function s(t,e){return n[t+" "+e]||n[e+" "+t]||n[""+t+".*."+e]}function o(t,e){var i=r.exec(t);if(!i)return null;var n=[],r=i
    function s(t) {return i==Object.prototype.toString.call(t)}function o(t) {if(!n[t]) {var e=document.createElement
    function s(t,e){return n[t+" "+e]||n[e+"]"]}function o(t,e){var i=document.createElement("div");return i.innerHTML=("<div style=\"
    function s(t,e){return n[t+" "+e]||n[   t+" "+e+"*"]&&!/[\-+]/.test(e)||n[e]}function o(t,e){var i=0,n=t.nodeType;if(!e
    function s(t) {return i==Object.prototype.toString.call(t)}function o(t) {if(!n[t]) {var e=document.createElement
    function s(t) {return i==Object.prototype.toString.call(t)}function o(t) {if(!n[t]) {var e=document.createElement
    function s(t) {return i==Object.prototype.toString.call(t)}function o(t) {if(!n[t]) {var e=document.createElement
    function s(t) {return i==Object.prototype.toString.call(t)}function o(t) {if(!n[t]) {var e=document.createElement
    function s(t) {return i==Object.prototype.toString.call(t)}function o(t) {if(!n[t]) {var e=document.createElement
    function s(t) {return i==Object.prototype.toString.call(t)}function o(t) {if(!n[t]) {var e=document.createElement(
    function s(t) {return n/t.toString.call(t)}function o(t) {if(!t||s(t)!==i&&s(t)!=='number')throw Error("Invalid object
    function s(t) {return i==Object.prototype.toString.call(t)}function o(t) {if(!n instanceof t)throw new Error("Incorrect invocation
    function s(t) {return n[t]||Object.prototype.toString.
    call(t).match(r)[2]}function o(t,e,i) {if (Array.isArray(t)) return a(t,e);var r=s(t),a=n[r];if ("Map"===r || "Set"call(t).match(i)=="[call(t).match(i)=="[call(t).match(i)=="[ call(t).call(t).match(i)=="[call(t).match(i)=="[call(t).match(i)=="[call(t).match(i)=="[call(t).match(i)=="[    call(t).match(i)=="[call(t).match(i)=="[call(t).match(i)=="[call(t).match(i)=="[call(t).match(i)=="[call(t).match(i)=="[call(t).match(i)=="[call(t).match(i)=="[ call(t).match(icall(t).match(i)=="[call(t).match(i)=="[call(t).match(i)=="[call(t).match(i)=="[call(t).match(i)=="[