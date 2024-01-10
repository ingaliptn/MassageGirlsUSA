$(document).ready(function () {
    debugger;
	var touch = $('#wsMobileNavIcon');
	var menu 	= $('.menu');

	$(touch).on('click', function (e) {
        debugger;
		e.preventDefault();
		menu.slideToggle();
	});
	
	$(window).resize(function(){
		var w = $(window).width();
		if(w > 767 && menu.is(':hidden')) {
			menu.removeAttr('style');
		}
	});
	
});