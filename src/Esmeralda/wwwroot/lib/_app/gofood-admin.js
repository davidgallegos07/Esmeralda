$("document").ready(function(){$("#side-menu").metisMenu(),$(function(){$(window).bind("load",function(){console.log($(this).width()),$(this).width()<753?$("div.sidebar-collapse").addClass("collapse"):$("div.sidebar-collapse").removeClass("collapse")})}),$(function(){$(window).bind("resize",function(){console.log($(this).width()),this.innerWidth<768?$("div.sidebar-collapse").addClass("collapse"):$("div.sidebar-collapse").removeClass("collapse")})});var n=!1;$(".btn-chk").click(function(){n?(n=!1,$("input:checkbox").prop("checked",0)):(n=!0,$("input:checkbox").prop("checked",1))}),$(function(){$("."),$(".msjadd").hide(2500)}),$("#myModal").on("hidden.bs.modal",function(n){}),window.oncontextmenu=function(){return!1},document.onkeydown=function(){return!1},document.onkeydown=function(n){return 123==window.event.keyCode||2==n.button||17==n.button||42==n.button||47==n.button||85==n.button||43==n.button||17==event.keyCode?!1:void 0}});