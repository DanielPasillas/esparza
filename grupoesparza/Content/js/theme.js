
/* Table of Content
====================
1. Page transitions / preloader
2. Disable right click
3. Smooth scrolling
4. Header
5. Main menu
6. Page header
7. Defer videos
8. Isotope
9. OWL Carousel
10. lightGallery
11. YTPlayer
12. Add to favorite button
13. Universal PHP Mail Feedback Script
14. Fade out element with page scroll
15. Parallax effect
16. Remove input placeholder on focus
17. Albums
18. Single gallery
19. Limit number of characters/words in element
20. Footer
21. Scroll to top button
22. Miscellaneous
*/
var $document = $(document),
  $window = $(window),
  $html = $("html"),
  $body = $("body"),

  isDesktop = $html.hasClass("desktop");

var plugins = {
  rdNavbar: $(".rd-navbar"),
  counter: $(".counter"),
  rdMailForm: $(".rd-mailform"),
  rdInputLabel: $(".form-label"),
  regula: $("[data-constraints]"),
  radio: $("input[type='radio']"),
  checkbox: $("input[type='checkbox']"),
  captcha: $('.recaptcha'),
  mailchimp: $('.mailchimp-mailform'),
  customToggle: $("[data-custom-toggle]"),
  campaignMonitor: $('.campaign-mailform')
};


(function ($) {
	'use strict';


  var isNoviBuilder = window.xMode;

  $window.load(function () {
    setTimeout(function () {
      $('body').addClass('loader-effect')
    }, 500);


    $(".animsition").animsition({
      inClass: 'fade-in',
      outClass: 'fade-out',
      inDuration: 800,
      outDuration: 500,
      // linkElement:   '.animsition-link',
      linkElement: 'a:not([target="_blank"]):not([href^="#"]):not([class*="lg-trigger"])', // e.g. linkElement: 'a:not([target="_blank"]):not([href^="#"])'
      loading: true,
      loadingParentElement: 'html', //animsition wrapper element
      loadingClass: 'animsition-loading',
      loadingInner: '', // e.g '<img src="assets/img/loading.svg" />'
      timeout: true,
      timeoutCountdown: 400,
      onLoadEvent: true,
      browser: ['animation-duration', '-webkit-animation-duration', '-o-animation-duration'], // "browser" option allows you to disable the "animsition" in case the css property in the array is not supported by your browser. The default setting is to disable the "animsition" in a browser that does not support "animation-duration".

      overlay : false,
      overlayClass : 'animsition-overlay-slide',
      overlayParentElement : 'html',
      transition: function(url){ window.location.href = url; }
    });
  });

	// ======================================== =======
	// Page transitions / preloader (Animsition)
	// More info: http://git.blivesta.com/animsition/
	// ===============================================




  /**
   * attachFormValidator
   * @description  attach form validation to elements
   */
  function attachFormValidator(elements) {
    for (var i = 0; i < elements.length; i++) {
      var o = $(elements[i]), v;
      o.addClass("form-control-has-validation").after("<span class='form-validation'></span>");
      v = o.parent().find(".form-validation");
      if (v.is(":last-child")) {
        o.addClass("form-control-last-child");
      }
    }

    elements
      .on('input change propertychange blur', function (e) {
        var $this = $(this), results;

        if (e.type !== "blur") {
          if (!$this.parent().hasClass("has-error")) {
            return;
          }
        }

        if ($this.parents('.rd-mailform').hasClass('success')) {
          return;
        }

        if ((results = $this.regula('validate')).length) {
          for (i = 0; i < results.length; i++) {
            $this.siblings(".form-validation").text(results[i].message).parent().addClass("has-error")
          }
        } else {
          $this.siblings(".form-validation").text("").parent().removeClass("has-error")
        }
      })
      .regula('bind');

    var regularConstraintsMessages = [
      {
        type: regula.Constraint.Required,
        newMessage: "The text field is required."
      },
      {
        type: regula.Constraint.Email,
        newMessage: "The email is not a valid email."
      },
      {
        type: regula.Constraint.Numeric,
        newMessage: "Only numbers are required"
      },
      {
        type: regula.Constraint.Selected,
        newMessage: "Please choose an option."
      }
    ];


    for (var i = 0; i < regularConstraintsMessages.length; i++) {
      var regularConstraint = regularConstraintsMessages[i];

      regula.override({
        constraintType: regularConstraint.type,
        defaultMessage: regularConstraint.newMessage
      });
    }
  }

  /**
   * isValidated
   * @description  check if all elemnts pass validation
   */
  function isValidated(elements, captcha) {
    var results, errors = 0;

    if (elements.length) {
      for (j = 0; j < elements.length; j++) {

        var $input = $(elements[j]);
        if ((results = $input.regula('validate')).length) {
          for (k = 0; k < results.length; k++) {
            errors++;
            $input.siblings(".form-validation").text(results[k].message).parent().addClass("has-error");
          }
        } else {
          $input.siblings(".form-validation").text("").parent().removeClass("has-error")
        }
      }

      if (captcha) {
        if (captcha.length) {
          return validateReCaptcha(captcha) && errors === 0
        }
      }

      return errors === 0;
    }
    return true;
  }

  /**
   * Radio
   * @description Add custom styling options for input[type="radio"]
   */
  if (plugins.radio.length) {
    var i;
    for (i = 0; i < plugins.radio.length; i++) {
      $(plugins.radio[i]).addClass("radio-custom").after("<span class='radio-custom-dummy'></span>")
    }
  }

  /**
   * Checkbox
   * @description Add custom styling options for input[type="checkbox"]
   */
  if (plugins.checkbox.length) {
    var i;
    for (i = 0; i < plugins.checkbox.length; i++) {
      $(plugins.checkbox[i]).addClass("checkbox-custom").after("<span class='checkbox-custom-dummy'></span>")
    }
  }

  /**
   * RD Input Label
   * @description Enables RD Input Label Plugin
   */

  if (plugins.rdInputLabel.length) {
    plugins.rdInputLabel.RDInputLabel();
  }


  /**
   * Regula
   * @description Enables Regula plugin
   */

  if (plugins.regula.length) {
    attachFormValidator(plugins.regula);
  }


  /**
   * MailChimp Ajax subscription
   */

  if (plugins.mailchimp.length) {
    for (i = 0; i < plugins.mailchimp.length; i++) {
      var $mailchimpItem = $(plugins.mailchimp[i]),
        $email = $mailchimpItem.find('input[type="email"]');

      // Required by MailChimp
      $mailchimpItem.attr('novalidate', 'true');
      $email.attr('name', 'EMAIL');

      $mailchimpItem.on('submit', $.proxy(function (e) {
        e.preventDefault();

        var $this = this;

        var data = {},
          url = $this.attr('action').replace('/post?', '/post-json?').concat('&c=?'),
          dataArray = $this.serializeArray(),
          $output = $("#" + $this.attr("data-form-output"));

        for (i = 0; i < dataArray.length; i++) {
          data[dataArray[i].name] = dataArray[i].value;
        }

        $.ajax({
          data: data,
          url: url,
          dataType: 'jsonp',
          error: function (resp, text) {
            $output.html('Server error: ' + text);

            setTimeout(function () {
              $output.removeClass("active");
            }, 4000);
          },
          success: function (resp) {
            $output.html(resp.msg).addClass('active');

            setTimeout(function () {
              $output.removeClass("active");
            }, 6000);
          },
          beforeSend: function (data) {
            // Stop request if builder or inputs are invalide
            if (isNoviBuilder || !isValidated($this.find('[data-constraints]')))
              return false;

            $output.html('Submitting...').addClass('active');
          }
        });

        return false;
      }, $mailchimpItem));
    }
  }


  /**
   * Campaign Monitor ajax subscription
   */
  if (plugins.campaignMonitor.length) {
    for (i = 0; i < plugins.campaignMonitor.length; i++) {
      var $campaignItem = $(plugins.campaignMonitor[i]);

      $campaignItem.on('submit', $.proxy(function (e) {
        var data = {},
          url = this.attr('action'),
          dataArray = this.serializeArray(),
          $output = $("#" + plugins.campaignMonitor.attr("data-form-output")),
          $this = $(this);

        for (i = 0; i < dataArray.length; i++) {
          data[dataArray[i].name] = dataArray[i].value;
        }

        $.ajax({
          data: data,
          url: url,
          dataType: 'jsonp',
          error: function (resp, text) {
            $output.html('Server error: ' + text);

            setTimeout(function () {
              $output.removeClass("active");
            }, 4000);
          },
          success: function (resp) {
            $output.html(resp.Message).addClass('active');

            setTimeout(function () {
              $output.removeClass("active");
            }, 6000);
          },
          beforeSend: function (data) {
            // Stop request if builder or inputs are invalide
            if (isNoviBuilder || !isValidated($this.find('[data-constraints]')))
              return false;

            $output.html('Submitting...').addClass('active');
          }
        });

        return false;
      }, $campaignItem));
    }
  }


  /**
   * RD Mailform
   * @version      3.2.0
   */
  if (plugins.rdMailForm.length) {
    var i, j, k,
      msg = {
        'MF000': 'Successfully sent!',
        'MF001': 'Recipients are not set!',
        'MF002': 'Form will not work locally!',
        'MF003': 'Please, define email field in your form!',
        'MF004': 'Please, define type of your form!',
        'MF254': 'Something went wrong with PHPMailer!',
        'MF255': 'Aw, snap! Something went wrong.'
      };

    for (i = 0; i < plugins.rdMailForm.length; i++) {
      var $form = $(plugins.rdMailForm[i]),
        formHasCaptcha = false;

      $form.attr('novalidate', 'novalidate').ajaxForm({
        data: {
          "form-type": $form.attr("data-form-type") || "contact",
          "counter": i
        },
        beforeSubmit: function (arr, $form, options) {
          if (isNoviBuilder)
            return;

          var form = $(plugins.rdMailForm[this.extraData.counter]),
            inputs = form.find("[data-constraints]"),
            output = $("#" + form.attr("data-form-output")),
            captcha = form.find('.recaptcha'),
            captchaFlag = true;

          output.removeClass("active error success");

          if (isValidated(inputs, captcha)) {

            // veify reCaptcha
            if (captcha.length) {
              var captchaToken = captcha.find('.g-recaptcha-response').val(),
                captchaMsg = {
                  'CPT001': 'Please, setup you "site key" and "secret key" of reCaptcha',
                  'CPT002': 'Something wrong with google reCaptcha'
                };

              formHasCaptcha = true;

              $.ajax({
                method: "POST",
                url: "bat/reCaptcha.php",
                data: {'g-recaptcha-response': captchaToken},
                async: false
              })
                .done(function (responceCode) {
                  if (responceCode !== 'CPT000') {
                    if (output.hasClass("snackbars")) {
                      output.html('<p><span class="icon text-middle mdi mdi-check icon-xxs"></span><span>' + captchaMsg[responceCode] + '</span></p>')

                      setTimeout(function () {
                        output.removeClass("active");
                      }, 3500);

                      captchaFlag = false;
                    } else {
                      output.html(captchaMsg[responceCode]);
                    }

                    output.addClass("active");
                  }
                });
            }

            if (!captchaFlag) {
              return false;
            }

            form.addClass('form-in-process');

            if (output.hasClass("snackbars")) {
              output.html('<p><span class="icon text-middle fa fa-circle-o-notch fa-spin icon-xxs"></span><span>Sending</span></p>');
              output.addClass("active");
            }
          } else {
            return false;
          }
        },
        error: function (result) {
          if (isNoviBuilder)
            return;

          var output = $("#" + $(plugins.rdMailForm[this.extraData.counter]).attr("data-form-output")),
            form = $(plugins.rdMailForm[this.extraData.counter]);

          output.text(msg[result]);
          form.removeClass('form-in-process');

          if (formHasCaptcha) {
            grecaptcha.reset();
          }
        },
        success: function (result) {
          if (isNoviBuilder)
            return;

          var form = $(plugins.rdMailForm[this.extraData.counter]),
            output = $("#" + form.attr("data-form-output")),
            select = form.find('select');

          form
            .addClass('success')
            .removeClass('form-in-process');

          if (formHasCaptcha) {
            grecaptcha.reset();
          }

          result = result.length === 5 ? result : 'MF255';
          output.text(msg[result]);

          if (result === "MF000") {
            if (output.hasClass("snackbars")) {
              output.html('<p><span class="icon text-middle mdi mdi-check icon-xxs"></span><span>' + msg[result] + '</span></p>');
            } else {
              output.addClass("active success");
            }
          } else {
            if (output.hasClass("snackbars")) {
              output.html(' <p class="snackbars-left"><span class="icon fa fa-exclamation text-middle"></span><span>' + msg[result] + '</span></p>');
            } else {
              output.addClass("active error");
            }
          }

          form.clearForm();

          if (select.length) {
            select.select2("val", "");
          }

          form.find('input, textarea').trigger('blur');

          setTimeout(function () {
            output.removeClass("active error success");
            form.removeClass('success');
          }, 3500);
        }
      });
    }
  }




	// ==========================================
	// Disable right click (uncomment if needed)
	// ==========================================

	// $(document)[0].oncontextmenu = function() { return false; }
	// $(document).mousedown(function(e) {
	//   if( e.button == 2 ) {
	//       alert('Sorry, this functionality is disabled!');
	//       return false;
	//   } else {
	//       return true;
	//   }
	// });

  /**
   * isScrolledIntoView
   * @description  check the element whas been scrolled into the view
   */
  function isScrolledIntoView(elem) {
    if (!isNoviBuilder) {
      return elem.offset().top + elem.outerHeight() >= $window.scrollTop() && elem.offset().top <= $window.scrollTop() + $window.height();
    }
    else {
      return true;
    }
  }





  /**
   * jQuery Count To
   * @description Enables Count To plugin
   */
  if (plugins.counter.length) {
    var i;

    for (i = 0; i < plugins.counter.length; i++) {
      var $counterNotAnimated = $(plugins.counter[i]).not('.animated');
      $document
        .on("scroll", $.proxy(function () {
          var $this = this;

          if ((!$this.hasClass("animated")) && (isScrolledIntoView($this))) {
            $this.countTo({
              refreshInterval: 40,
              from: 0,
              to: parseInt($this.text(), 10),
              speed: $this.attr("data-speed") || 1000
            });
            $this.addClass('animated');
          }
        }, $counterNotAnimated))
        .trigger("scroll");
    }
  }

  /**
   * WOW
   * @description Enables Wow animation plugin
   */
  if ($html.hasClass("wow-animation") && $(".wow").length) {
    new WOW().init();
  }



  /**
   * initOnView
   * @description  calls a function when element has been scrolled into the view
   */
  function lazyInit(element, func) {
    $window.on('load scroll', function () {
      if ((!element.hasClass('lazy-loaded') && (isScrolledIntoView(element)))) {
        func.call();
        element.addClass('lazy-loaded');
      }
    });
  }


  // =========================================================================
  // Smooth scrolling
  // Note: requires Easing plugin - http://gsgd.co.uk/sandbox/jquery/easing/
  // =========================================================================

  $('.sm-scroll').on("click",function() {
    if (location.pathname.replace(/^\//, '') === this.pathname.replace(/^\//, '') && location.hostname === this.hostname) {

      var target = $(this.hash);
      target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
      if (target.length) {
        $('html,body').animate({
          scrollTop: target.offset().top
        }, 1000, 'easeInOutExpo');
        return false;
      }
    }
  });







   // Header Filled (cbpAnimatedHeader)
   // More info: http://tympanus.net/codrops/2013/06/06/on-scroll-animated-header/
   // ====================================
   var cbpAnimatedHeader = (function() {

      var docElem = document.documentElement,
         header = document.querySelector( '#header' ),
         didScroll = false,
         changeHeaderOn = 1;

      function init() {
         window.addEventListener( 'scroll', function( event ) {
             if( !didScroll ) {
                 didScroll = true;
                 setTimeout( scrollPage, 300 );
             }
         }, false );
      }

      function scrollPage() {
         var sy = scrollY();
         if ($(this).scrollTop() > 150){
            $('#header.header-fixed-top, #header.header-show-hide-on-scroll').addClass("header-filled");
         }
         else{
            $('#header.header-fixed-top, #header.header-show-hide-on-scroll').removeClass("header-filled");
         }
            didScroll = false;
      }

      function scrollY() {
         return window.pageYOffset || docElem.scrollTop;
      }

      init();

   })();


   // Set padding-top to <body> if needed
   // ====================================
   $(window).resize(function() {

      // Make <body> padding-top equal to "#header" height if "#header" contains one of these classes: "header-fixed-top", "header-show-hide-on-scroll".
      if ($('#header').is('.header-fixed-top, .header-show-hide-on-scroll')) {
        $('body').css( 'padding-top', $('#header').css('height'));
      }

      // Set "body" padding-top to "0" if "#header" contains class: "header-transparent".
      if ($('#header').is('.header-transparent')) {
        $('body').css('padding-top', 0);
      }

   }).resize();

  // =======================
  // RD Navbar
  // =======================
  if (plugins.rdNavbar.length) {
    plugins.rdNavbar.RDNavbar({
      anchorNav: !isNoviBuilder,
      stickUpClone: (plugins.rdNavbar.attr("data-stick-up-clone") && !isNoviBuilder) ? plugins.rdNavbar.attr("data-stick-up-clone") === 'true' : false,
      responsive: {
        0: {
          stickUp: (!isNoviBuilder) ? plugins.rdNavbar.attr("data-stick-up") === 'true' : false
        },
        768: {
          stickUp: (!isNoviBuilder) ? plugins.rdNavbar.attr("data-sm-stick-up") === 'true' : false
        },
        992: {
          stickUp: (!isNoviBuilder) ? plugins.rdNavbar.attr("data-md-stick-up") === 'true' : false
        },
        1200: {
          stickUp: (!isNoviBuilder) ? plugins.rdNavbar.attr("data-lg-stick-up") === 'true' : false
        }
      },
      callbacks: {
        onStuck: function () {
          var navbarSearch = this.$element.find('.rd-search input');

          if (navbarSearch) {
            navbarSearch.val('').trigger('propertychange');
          }
        },
        onDropdownOver: function () {
          return !isNoviBuilder;
        },
        onUnstuck: function () {
          if (this.$clone === null)
            return;

          var navbarSearch = this.$clone.find('.rd-search input');

          if (navbarSearch) {
            navbarSearch.val('').trigger('propertychange');
            navbarSearch.trigger('blur');
          }
        }
      }
    });


    if (plugins.rdNavbar.attr("data-body-class")) {
      document.body.className += ' ' + plugins.rdNavbar.attr("data-body-class");
    }
  }





	// ===============================
	// Page header
	// ===============================

	// if #page-header exist add class "page-header-on" to <body>.
	if ($('#page-header').length) {
		$('body').addClass('page-header-on');
	}

	// if page header contains background image add class "ph-image-on" to #page-header.
	if ($('.page-header-image').length) {
		$('#page-header').addClass('ph-image-on');
	}

	// if class "hide-ph-image" exist remove class "ph-image-on".
	if ($('.page-header-image').hasClass('hide-ph-image')) {
		$('#page-header').removeClass('ph-image-on');
	}



	// =======================================================================================
	// Defer videos (Youtube, Vimeo)
	// Note: When you have embed videos in your webpages it causes your page to load slower.
	// Deffering will allow your page to load quickly.
	// Source: https://www.feedthebot.com/pagespeed/defer-videos.html
	// =======================================================================================

	function init() {
	var vidDefer = document.getElementsByTagName('iframe');
	for (var i=0; i<vidDefer.length; i++) {
	if(vidDefer[i].getAttribute('data-src')) {
	vidDefer[i].setAttribute('src',vidDefer[i].getAttribute('data-src'));
	} } }
	window.onload = init;



	// ===================================================================================
	// Isotope
	// Source: http://isotope.metafizzy.co
	// Note: "imagesloaded" blugin is required: https://github.com/desandro/imagesloaded
	// ===================================================================================

	// init Isotope
	var $container = $('.isotope-items-wrap');
	$container.imagesLoaded(function() {
		$container.isotope({
			itemSelector: '.isotope-item',
			transitionDuration: '0.7s',
			masonry: {
				columnWidth: '.grid-sizer',
				horizontalOrder: false
			}
		});
	});

	// Filter
	$('.isotope-filter-links a').on("click",function(){
		var selector = $(this).attr('data-filter');
		$container.isotope({
			filter: selector
		});
		return false;
	});

	// Filter item active
	var filterItemActive = $('.isotope-filter-links a');
	filterItemActive.on('click', function(){
		var $this = $(this);
		if ( !$this.hasClass('active')) {
			filterItemActive.removeClass('active');
			$this.addClass('active');
		}
	});


	// If "isotope-top-content" exist add class ".iso-top-content-on" to <body>.
	if ($('.isotope-top-content').length) {
		$('body').addClass('iso-top-content-on');
	}

	// If ".isotope-filter" contains class "fi-to-button" add class "fi-to-button-on" to ".isotope-top-content".
	if ($('.isotope-filter').hasClass('fi-to-button')) {
		$('.isotope-top-content').addClass('fi-to-button-on');
	}

	// If ".isotope-filter" contains class "fi-to-button" add class "fi-to-button-on" to ".isotope-top-content".
	if ($('.gallery-share').length) {
		$('.isotope-top-content').addClass('gallery-share-on');
	}

	// Filter button clickable/hover (clickable on small screens)
	if ( $(window).width() < 992) {

		// Filter button clickable (effect on small screens)
		$('.isotope-filter-button').on("click",function(){
			$('.isotope-filter').toggleClass('iso-filter-open');
		});

		// Close filter button if click on filter links (effect only on small screens)
		$('ul.isotope-filter-links > li > a').on("click",function() {
			$(".isotope-filter-button").click();
		});

	} else {

		// Filter button on hover
		$('.isotope-filter').on("mouseenter",function(){
			$('.isotope-filter').addClass('iso-filter-open');
		}).on("mouseleave",function(){
			$('.isotope-filter').removeClass('iso-filter-open');
		});

	}


	// if class "isotope" exist.
	if ($('.isotope').length){
		
		// add overflow scroll to <html> (isotope items gaps fix).
		if ( document.querySelector('body').offsetHeight > window.innerHeight ) {
			document.documentElement.style.overflowY = 'scroll';
		}

		// Add class "isotope-on" to <body>.
		$('body').addClass('isotope-on');
	}


	// Add class "iso-gutter-*-on" to <body> if ".isotope" contains class "gutter-*".
	if ($('.isotope').hasClass('gutter-1')) {
		$('body').addClass('iso-gutter-1-on');
	}

	if ($('.isotope').hasClass('gutter-2')) {
		$('body').addClass('iso-gutter-2-on');
	}

	if ($('.isotope').hasClass('gutter-3')) {
		$('body').addClass('iso-gutter-3-on');
	}


	// Add class "iso-tt-wrap-on" to <body> if ".isotope-wrap" contains class "tt-wrap".
	if ($('.isotope-wrap').hasClass('tt-wrap')) {
		$('body').addClass('iso-tt-wrap-on');
	}



	// ===============================================
	// OWL Carousel
	// Source: http://www.owlcarousel.owlgraphic.com
	// ===============================================

	$(window).on('load', function() { // fixes Owl Carousel "autoWidth: true" issue (https://github.com/OwlCarousel2/OwlCarousel2/issues/1139).

		$('.owl-carousel').each(function(){
			var $carousel = $(this);

      if ($carousel.attr('data-nav-custom')) {
        $carousel.on("initialized.owl.carousel", function (event) {
          var carousel = $(event.currentTarget),
            customNav = $(carousel.attr("data-nav-custom"));

          // Custom Navigation Events
          customNav.find(".owl-arrow-next").click(function (e) {
            e.preventDefault();
            carousel.trigger('next.owl.carousel', 800);
          });
          customNav.find(".owl-arrow-prev").click(function (e) {
            e.preventDefault();
            carousel.trigger('prev.owl.carousel', 800);
          });
        });
      }


      // Enable custom pagination
      if ($carousel.attr('data-dots-custom')) {
        $carousel.on("initialized.owl.carousel", function (event) {
          var carousel = $(event.currentTarget),
            customPag = $(carousel.attr("data-dots-custom")),
            active = 0;

          if (carousel.attr('data-active')) {
            active = parseInt(carousel.attr('data-active'));
          }

          carousel.trigger('to.owl.carousel', [active, 300, true]);
          customPag.find("[data-owl-item='" + active + "']").addClass("active");



          customPag.find("[data-owl-item]").each(function (index) {
            $(this).css({
              'background-image' : $($carousel.find('.owl-item')[index]).find('.cc-image').css('background-image')
            });
          });
          
          customPag.find("[data-owl-item]").on('click', function (e) {
            e.preventDefault();
            carousel.trigger('to.owl.carousel', [parseInt(this.getAttribute("data-owl-item")), 800, true]);
          });

          carousel.on("translate.owl.carousel", function (event) {
            customPag.find(".active").removeClass("active");
            customPag.find("[data-owl-item='" + event.item.index + "']").addClass("active")

          });
        });
      }


			$carousel.owlCarousel({

				items: $carousel.data("items"),
				loop: $carousel.data("loop"),
				margin: $carousel.data("margin"),
				center: $carousel.data("center"),
        thumbs: $carousel.data("thumbs"),
        thumbsPrerendered: $carousel.data("thumbs-prep"),
        thumbContainerClass: 'owl-thumbs',
        thumbItemClass: 'owl-thumb-item',
        thumbImage: $carousel.data("thumbs-image"),
				startPosition: $carousel.data("start-position"),
				animateIn: $carousel.data("animate-in"),
				animateOut: $carousel.data("animate-out"),
				autoWidth: $carousel.data("autowidth"),
				autoHeight: $carousel.data("autoheight"),
				autoplay: $carousel.data("autoplay"),
				autoplayTimeout: $carousel.data("autoplay-timeout"),
				autoplayHoverPause: $carousel.data("autoplay-hover-pause"),
				autoplaySpeed: $carousel.data("autoplay-speed"),
				nav: $carousel.data("nav"),
				navText: ['', ''],
				navSpeed: $carousel.data("nav-speed"),
				dots: $carousel.data("dots"),
				dotsSpeed: $carousel.data("dots-speed"),
				mouseDrag: $carousel.data("mouse-drag"),
				touchDrag: $carousel.data("touch-drag"),
				dragEndSpeed: $carousel.data("drag-end-speed"),
				lazyLoad: $carousel.data("lazy-load"),
				video: true,
				responsive: {
					0: {
						items: $carousel.data("mobile-portrait"),
						center: false,
					},
					480: {
						items: $carousel.data("mobile-landscape"),
						center: false,
					},
					768: {
						items: $carousel.data("tablet-portrait"),
						center: false,
					},
					992: {
						items: $carousel.data("tablet-landscape"),
					},
					1200: {
						items: $carousel.data("items"),
					}
				}

			});



			// Mousewheel plugin
			var owl = $('.owl-mousewheel');
			owl.on('mousewheel', '.owl-stage', function (e) {
				if (e.deltaY > 0) {
					owl.trigger('prev.owl', [800]);
				} else {
					owl.trigger('next.owl', [800]);
				}
				e.preventDefault();
			});




		});

	});


	// CC item hover
	$('.cc-item').on('mouseenter',function() {
		$('.owl-carousel').addClass('cc-item-hovered');
	});
	$('.cc-item').on('mouseleave',function() {
		$('.owl-carousel').removeClass('cc-item-hovered');
	});

	// If ".cc-caption" exist add class "cc-caption-on" to ".cc-item".
	$('.cc-item').each(function() {
		if ($(this).find('.cc-caption').length) {
			$(this).addClass('cc-caption-on');
		}
	});



	// =====================================================
	// lightGallery (lightbox plugin)
	// Source: http://sachinchoolur.github.io/lightGallery
	// =====================================================

	$(".lightgallery").lightGallery({

		// Please read about gallery options here: http://sachinchoolur.github.io/lightGallery/docs/api.html

		// lightgallery core 
		selector: '.lg-trigger',
		mode: 'lg-fade', // Type of transition between images ('lg-fade' or 'lg-slide').
		height: '100%', // Height of the gallery (ex: '100%' or '300px').
		width: '100%', // Width of the gallery (ex: '100%' or '300px').
		iframeMaxWidth: '100%', // Set maximum width for iframe.
		loop: true, // If false, will disable the ability to loop back to the beginning of the gallery when on the last element.
		speed: 600, // Transition duration (in ms).
		closable: true, // Allows clicks on dimmer to close gallery.
		escKey: true, // Whether the LightGallery could be closed by pressing the "Esc" key.
		keyPress: true, // Enable keyboard navigation.
		hideBarsDelay: 5000, // Delay for hiding gallery controls (in ms).
		controls: true, // If false, prev/next buttons will not be displayed.
		mousewheel: true, // Chane slide on mousewheel.
		download: false, // Enable download button. By default download url will be taken from data-src/href attribute but it supports only for modern browsers. If you want you can provide another url for download via data-download-url.
		counter: true, // Whether to show total number of images and index number of currently displayed image.
		swipeThreshold: 50, // By setting the swipeThreshold (in px) you can set how far the user must swipe for the next/prev image.
		enableDrag: true, // Enables desktop mouse drag support.
		enableTouch: true, // Enables touch support.

		// thumbnial plugin
		thumbnail: true, // Enable thumbnails for the gallery.
		showThumbByDefault: false, // Show/hide thumbnails by default.
		thumbMargin: 5, // Spacing between each thumbnails.
		toogleThumb: true, // Whether to display thumbnail toggle button.
		enableThumbSwipe: true, // Enables thumbnail touch/swipe support for touch devices.
		exThumbImage: 'data-exthumbnail', // If you want to use external image for thumbnail, add the path of that image inside "data-" attribute and set value of this option to the name of your custom attribute.

		// autoplay plugin
		autoplay: false, // Enable gallery autoplay.
		autoplayControls: true, // Show/hide autoplay controls.
		pause: 6000, // The time (in ms) between each auto transition.
		progressBar: true, // Enable autoplay progress bar.
		fourceAutoplay: false, // If false autoplay will be stopped after first user action

		// fullScreen plugin
		fullScreen: true, // Enable/Disable fullscreen mode.

		// zoom plugin
		zoom: true, // Enable/Disable zoom option.
		scale: 0.5, // Value of zoom should be incremented/decremented.
		enableZoomAfter: 50, // Some css styles will be added to the images if zoom is enabled. So it might conflict if you add some custom styles to the images such as the initial transition while opening the gallery. So you can delay adding zoom related styles to the images by changing the value of enableZoomAfter.

		// video options
		videoMaxWidth: '1000px', // Set limit for video maximal width.

		// Youtube video options
		loadYoutubeThumbnail: true, // You can automatically load thumbnails for youtube videos from youtube by setting loadYoutubeThumbnail true.
		youtubeThumbSize: 'default', // You can specify the thumbnail size by setting respective number: 0, 1, 2, 3, 'hqdefault', 'mqdefault', 'default', 'sddefault', 'maxresdefault'.
		youtubePlayerParams: { // Change youtube player parameters: https://developers.google.com/youtube/player_parameters
			modestbranding: 0,
			showinfo: 1,
			controls: 1
		},

		// Vimeo video options
		loadVimeoThumbnail: true, // You can automatically load thumbnails for vimeo videos from vimeo by setting loadYoutubeThumbnail true.
		vimeoThumbSize: 'thumbnail_medium', // Thumbnail size for vimeo videos: 'thumbnail_large' or 'thumbnail_medium' or 'thumbnail_small'.
		vimeoPlayerParams: { // Change vimeo player parameters: https://developer.vimeo.com/player/embedding#universal-parameters 
			byline : 1,
			portrait : 1,
			title: 1,
			color : 'CCCCCC',
			autopause: 1
		},

		// hash plugin (unique url for each slides)
		hash: true, // Enable/Disable hash plugin.
		hgalleryId: 1, // Unique id for each gallery. It is mandatory when you use hash plugin for multiple galleries on the same page.

		// share plugin
		share: false, // Enable/Disable share plugin.
			facebook: true, // Enable Facebook share.
			facebookDropdownText: 'Facebook', // Facebok dropdown text.
			twitter: true, // Enable Twitter share.
			twitterDropdownText: 'Twitter', // Twitter dropdown text.
			googlePlus: true, // Enable Google Plus share.
			googlePlusDropdownText: 'Google+', // Google Plus dropdown text.
			pinterest: true, // Enable Pinterest share.
			pinterestDropdownText: 'Pinterest' // Pinterest dropdown text.

	});



	// =======================================================
	// YTPlayer (Background Youtube video)
	// Source: https://github.com/pupunzi/jquery.mb.YTPlayer
	// =======================================================

	// Disabled on mobile devices, because video background doesn't work on mobile devices (instead the background image is displayed).
	if (!jQuery.browser.mobile) { 
		$(".youtube-bg").mb_YTPlayer();
	}



	// ==============================================================================
	// Add to favorite button
	// Source: http://www.webdesigncrowd.com/demo/circle-reveal-animation-12.23.13/
	// ==============================================================================

	$(".fav-count").on("click",function() {
		var total = parseInt($(this).html(), 10);
		$(this).parent().toggleClass("active");

    if ($(this).parent().hasClass("active")) {
      total += 1;
    } else {
      total -= 1;
    }
    $(this).html(total);
	});

	$(".icon-heart").on("click",function() {
		var total = parseInt($(this).parent().siblings(".fav-count").first().html(), 10);
		if ($(this).parent().parent().hasClass("active")) {
			total -= 1;
		} else {
			total += 1;
		}
		$(this).parent().siblings(".fav-count").first().html(total);
		$(this).parent().parent().toggleClass("active");
	});



 


	// ==================================
	// Fade out element with page scroll
	// ==================================

	$(window).scroll(function(){
		if ($(window).width() > 992) { // disable fade out on small screens
			$(".fade-out-scroll-1").css("opacity", 1 - $(window).scrollTop() / 2000);
			$(".fade-out-scroll-2").css("opacity", 1 - $(window).scrollTop() / 2000);
			$(".fade-out-scroll-3").css("opacity", 1 - $(window).scrollTop() / 2000);
			$(".fade-out-scroll-4").css("opacity", 1 - $(window).scrollTop() / 2000);
			$(".fade-out-scroll-5").css("opacity", 1 - $(window).scrollTop() / 2000);
			$(".fade-out-scroll-6").css("opacity", 1 - $(window).scrollTop() / 2000);
			$(".fade-out-scroll-7").css("opacity", 1 - $(window).scrollTop() / 2000);
			$(".fade-out-scroll-8").css("opacity", 1 - $(window).scrollTop() / 2000);
		}
	});



	// ========================
	// Parallax effect
	// ========================

	$(window).scroll(function(){
		var bgScroll = $(this).scrollTop();

		// parallax - image background position
		$('.parallax-bg-1').css('background-position','center '+ ((bgScroll * 0.1)) +'px');
		$('.parallax-bg-2').css('background-position','center '+ ((bgScroll * 0.1)) +'px');
		$('.parallax-bg-3').css('background-position','center '+ ((bgScroll * 0.1)) +'px');
		$('.parallax-bg-4').css('background-position','center '+ ((bgScroll * 0.1)) +'px');
		$('.parallax-bg-5').css('background-position','center '+ ((bgScroll * 0.1)) +'px');
		$('.parallax-bg-6').css('background-position','center '+ ((bgScroll * 0.1)) +'px');

	});


	$(window).scroll(function(){
		var bgScroll = $(this).scrollTop();
		if ($(window).width() > 992) { // disable parallax on small screens

			// parallax - transform
			$('.parallax-1').css('transform', 'translate3d(0, '+ ((bgScroll * 0.1)) +'px, 0)');
			$('.parallax-2').css('transform', 'translate3d(0, '+ ((bgScroll * 0.1)) +'px, 0)');
			$('.parallax-3').css('transform', 'translate3d(0, '+ ((bgScroll * 0.1)) +'px, 0)');
			$('.parallax-4').css('transform', 'translate3d(0, '+ ((bgScroll * 0.1)) +'px, 0)');
			$('.parallax-5').css('transform', 'translate3d(0, '+ ((bgScroll * 0.1)) +'px, 0)');
			$('.parallax-6').css('transform', 'translate3d(0, '+ ((bgScroll * 0.1)) +'px, 0)');

			// parallax - top
			// $('.parallax-top').css('top', ''+ ((bgScroll*0.9)) +'px');
		}
	});



	// ==================================
	// Remove input placeholder on focus
	// ==================================

   $('input,textarea').focus(function () {
      $(this).data('placeholder', $(this).attr('placeholder'))
         .attr('placeholder', '');
   }).blur(function () {
      $(this).attr('placeholder', $(this).data('placeholder'));
   });



	// ==================================
	// Albums
	// ==================================

	// Rotate thumb-list items randomly (in gallery-list-carousel)
	$(".thumb-list.tl-rotate > li").each( function() {
		var rNum = (Math.random()*50)-25;  
			$(this).css( {
			'-webkit-transform': 'rotate('+rNum+'2deg)',
			'-moz-transform': 'rotate('+rNum+'2deg)'  
		});  
	});



	// ==================================
	// Single gallery
	// ==================================

	// Gallery single carousel 
	// ========================

	// Make carousel info same width as ".gs-carousel-wrap" on small devices
	$(window).resize(function() {
		if ($(window).width() < 768) {
			var gscwWidth = $('.gs-carousel-wrap').width();
			$('.gs-carousel-info').css({
				'width': gscwWidth
			});
		} else {
			$('.gs-carousel-info').css({
				'width': 440
			});
		}
	}).resize();



	// ============================================
	// Limit number of characters/words in element
	// ============================================

	// Limit number of characters in element (example: data-max-characters="120")
	$("div, p, a").each(function() {
		var textMaxChar = $(this).attr('data-max-characters');

		var length = $(this).text().length;
		if(length > textMaxChar) {
			$(this).text($(this).text().substr(0, textMaxChar)+'...');
		}
	});

	// Limit number of words in element (example: data-max-words="40")
	$("div, p, a").each(function() {
		var textMaxWords = $(this).attr('data-max-words');
		var text = $(this).text();

		var length = text.split(' ').length;
		if(length > textMaxWords) {
			var lastWord = text.split(' ')[textMaxWords];
			var lastWordIndex = text.indexOf(lastWord);
				$(this).text(text.substr(0, lastWordIndex) + '...');
		}
	});



	// ======================
	// Footer
	// ======================

	// If "#footer" contains class "footer-minimal" add class "footer-minimal-on" to <body>.
	if ($('#footer').hasClass('footer-minimal')) {
		$('body').addClass('footer-minimal-on');
	}



	// ======================
	// Scroll to top button
	// ======================

	// Check to see if the window is top if not then display button
	$(window).scroll(function(){
		if ($(this).scrollTop() > 500) {
			$('.scrolltotop').fadeIn();
		} else {
			$('.scrolltotop').fadeOut();
		}
	});



	// ===============
	// Miscellaneous
	// ===============

	// Bootstrap-3 modal fix
	$('.modal').appendTo("body");


	// Bootstrap tooltip
	$('[data-toggle="tooltip"]').tooltip();


	// Bootstrap popover
	$('[data-toggle="popover"]').popover({
		html: true
	});


  /**
   * Custom Toggles
   */
  if (plugins.customToggle.length) {
    var i;

    for (i = 0; i < plugins.customToggle.length; i++) {
      var $this = $(plugins.customToggle[i]);

      $this.on('click', $.proxy(function (event) {
        event.preventDefault();
        var $ctx = $(this);
        $($ctx.attr('data-custom-toggle')).add(this).toggleClass('active');
      }, $this));

      if ($this.attr("data-custom-toggle-hide-on-blur") === "true") {
        $("body").on("click", $this, function (e) {
          if (e.target !== e.data[0]
            && $(e.data.attr('data-custom-toggle')).find($(e.target)).length
            && e.data.find($(e.target)).length == 0) {
            $(e.data.attr('data-custom-toggle')).add(e.data[0]).removeClass('active');
          }
        })
      }

      if ($this.attr("data-custom-toggle-disable-on-blur") === "true") {
        $("body").on("click", $this, function (e) {
          if (e.target !== e.data[0] && $(e.data.attr('data-custom-toggle')).find($(e.target)).length == 0 && e.data.find($(e.target)).length == 0) {
            $(e.data.attr('data-custom-toggle')).add(e.data[0]).removeClass('active');
          }
        })
      }

      $window.on('load resize', function () {
        var footerHeight = $('#footer').innerHeight();
        console.log(footerHeight);
        $this.css({
          'height' : footerHeight,
          'width' : footerHeight
        })
      })
    }
  }



})(jQuery); 
