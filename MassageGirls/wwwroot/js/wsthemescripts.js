/*
jQuery(document).ready(function() {
	showHideLoading()
});

function showHideLoading() {
	var a = jQuery(".ws-loader");

	function b() {
		jQuery("body").bind("mousewheel", function() {
			return false
		})
	}
	a.show();
	jQuery(window).on("load", function() {
		a.fadeOut()
	})
}
*/
jQuery("ul.sf-menu").superfish({
	delay: 800,
	animation: {
		opacity: "show",
		height: "show"
	},
	speed: "normal",
	cssArrows: true
});
jQuery("#wsBackTop").click(function() {
	jQuery("body").slideto({
		highlight: false
	})
});
jQuery(".page a[href*=#]").click(function(a) {
	jQuery("html, body").animate({
		scrollTop: jQuery(jQuery.attr(this, "href")).offset().top - 130
	}, 500);
	a.preventDefault()
});
jQuery(window).scroll(function() {
	jQuery(this).scrollTop() ? (jQuery("#wsBackTop").css("bottom", "-50px")) : (jQuery("#wsBackTop").css("bottom", "-100px")); 
	jQuery(this).scrollTop() ? (jQuery(".ws-scroll-down").css("display", "none")) : (jQuery(".ws-scroll-down").css("display", "block"))
});
jQuery(".fancybox").fancybox();
jQuery(".ws-gallery .item a").fancybox().attr("rel", "wp-gallery-fancybox");
jQuery(".ws-question h2").click(function() {
	jQuery(this).next(".ws-answer").slideToggle(500);
	jQuery(this).toggleClass("close")
});
jQuery("#reply-title").click(function() {
	jQuery(this).next("#commentform").slideToggle(500);
	jQuery(this).toggleClass("close")
});
jQuery(window).resize(function() {
	jQuery("#dimensions").html(jQuery(window).width())
}).resize();
equalheight = function(b) {
	var a = 0,
		c = 0,
		f = new Array(),
		e, d = 0;
	jQuery(b).each(function() {
		e = jQuery(this);
		jQuery(e).height("auto");
		topPostion = e.position().top;
		if (c != topPostion) {
			for (currentDiv = 0; currentDiv < f.length; currentDiv++) {
				f[currentDiv].height(a)
			}
			f.length = 0;
			c = topPostion;
			a = e.height();
			f.push(e)
		} else {
			f.push(e);
			a = (a < e.height()) ? (e.height()) : (a)
		}
		for (currentDiv = 0; currentDiv < f.length; currentDiv++) {
			f[currentDiv].height(a)
		}
	})
};
jQuery(window).load(function() {
	equalheight(".ws-grid h3.widget-title");
	equalheight(".ws-grid .summary p");
	equalheight("#wsTestimonialPage .widget");
});
jQuery(window).resize(function() {
	equalheight(".ws-grid h3.widget-title");
	equalheight(".ws-grid .summary p");
	equalheight("#wsTestimonialPage .widget");
});
var clickTabCurrent = 0;

function clickTabSwitch(a) {
	document.getElementById("clickTab" + clickTabCurrent).style.display = "none";
	document.getElementById("wsTabs_" + clickTabCurrent).className = "ws-tab";
	clickTabCurrent = a;
	document.getElementById("clickTab" + clickTabCurrent).style.display = "block";
	document.getElementById("wsTabs_" + clickTabCurrent).className = "ws-tab-current"
}


var nice = false;
nice = jQuery("#wsSite").niceScroll({
	cursorcolor: "#000",
	cursorwidth: "12px",
	cursorborder: "none",
	cursorborderradius: "0px",
	railpadding: "5px",
	zindex: "99999"
});
jQuery("#wsMobileNavLeft").click(function() {
	jQuery("#wsMobileNav nav").slideToggle();
	jQuery("#wsMobileNavIcon").toggleClass("open");
	return false
});
jQuery("#ws-mobile-nav > ul > li:has(ul)").addClass("has-sub");
jQuery("#ws-mobile-nav > ul > li > a").click(function() {
	var a = jQuery(this).next();
	jQuery("#ws-mobile-nav li").removeClass("active");
	jQuery(this).closest("li").addClass("active");
	if ((a.is("ul")) && (a.is(":visible"))) {
		jQuery(this).closest("li").removeClass("active");
		a.slideUp("fast")
	}
	if ((a.is("ul")) && (!a.is(":visible"))) {
		jQuery("#ws-mobile-nav ul ul:visible").slideUp("normal");
		a.slideDown("normal")
	}
	if (a.is("ul")) {
		return false
	} else {
		return true
	}
});
WebFontConfig = {
	google: {
		families: ["Roboto:300,400,500,700,900"]
	}
};
(function() {
	var a = document.createElement("script");
	a.src = "//ajax.googleapis.com/ajax/libs/webfont/1/webfont.js";
	a.type = "text/javascript";
	a.async = "true";
	var b = document.getElementsByTagName("script")[0];
	b.parentNode.insertBefore(a, b)
})();
/*
 jQuery(".ws-section, .ws-parallax-text").addClass("hidden").viewportChecker({
	classToAdd: "visible animated fadeIn",
	offset: 100,
});
*/