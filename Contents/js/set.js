	$(document).on("mobileinit", function(){
		// 初期値の上書き
		$.mobile.page.prototype.options.theme = "a";
		$.mobile.page.prototype.options.headerTheme = "a";
		$.mobile.page.prototype.options.contentTheme = "b";
		$.mobile.page.prototype.options.footerTheme = "a";

		$.mobile.ajaxEnabled=false;
		$.mobile.hashListeningEnabled=false;
		$.mobile.pushStateEnabled=false;
//		$.mobile.loadingMessageTextVisible = true;
		$("a").attr({ "data-ajax":"false" });
		$("form").attr({ "data-ajax":"false" });
//		$.mobile.button.prototype.options.corners=true;
//		$.mobile.button.prototype.options.shadow=true;
		$.mobile.button.prototype.options.theme="e";
		
	});
