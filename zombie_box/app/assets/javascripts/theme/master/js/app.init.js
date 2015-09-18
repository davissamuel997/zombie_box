/**
 * 
 * BeAdmin - Bootstrap Admin Theme - App Javascript
 * 
 * Author: @themicon_co
 * Website: http://themicon.co
 * License: http://support.wrapbootstrap.com/knowledge_base/topics/usage-licenses
 * 
 */

/**
 * Provides a start point to run plugins and other scripts
 */
(function($, window, document){
  'use strict';

  if (typeof $ === 'undefined') { throw new Error('This application\'s JavaScript requires jQuery'); }

  $(window).load(function() {

    $('.scroll-content').slimScroll({
        height: '250px'
    });

    adjustLayout();

  }).resize(adjustLayout);


  $(function() {

    // Init Fast click for mobiles
    FastClick.attach(document.body);

    // inhibits null links
    $('a[href="#"]').each(function(){
      this.href = 'javascript:void(0);';
    });

    // abort dropdown autoclose when exist inputs inside
    $(document).on('click', '.dropdown-menu input', function(e){
      e.stopPropagation();
    });

    // popover init
    $('[data-toggle=popover]').popover();

    // Bootstrap slider
    $('.slider').slider();

    // Chosen
    $('.chosen-select').chosen();

    // Filestyle
    $('.filestyle').filestyle();

    // Masked inputs initialization
    $.fn.inputmask && $('[data-toggle="masked"]').inputmask();

  });

  // keeps the wrapper covering always the entire body
  // necessary when main content doesn't fill the viewport
  function adjustLayout() {
    $('.wrapper > section').css('min-height', $(window).height());
  }

}(jQuery, window, document));
