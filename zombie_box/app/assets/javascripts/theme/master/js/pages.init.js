/**
 * 
 * BeAdmin - Bootstrap Admin Theme - Page Javascript
 * 
 * Author: @themicon_co
 * Website: http://themicon.co
 * License: http://support.wrapbootstrap.com/knowledge_base/topics/usage-licenses
 * 
 */

(function($, window, document){
  'use strict';

  // Document ready
  $(function(){

    adjustPageLayout();
    $(window).resize(adjustPageLayout);

    // Init Fast click for mobiles
    FastClick.attach(document.body);

    // Hook into accordion show event to add an active class
    // to panel-heading. Used in page login-multi.
    var Selector           = '[data-toggle="collapse-autoactive"]',
        panelHeading       = '.panel-heading',
        panelHeadingActive = 'panel-heading-active';
    
      $(document).on('show.bs.collapse', Selector, function (e) {
        // From the panel-group, deactive all headings
        $(e.currentTarget)
          .find(panelHeading)
          .removeClass(panelHeadingActive);
        // And activate the target heading
        $(e.target)
          .siblings(panelHeading)
          .addClass(panelHeadingActive);
      });


    // ----------------------------------------------------------
    // If you need Javascript components from the application 
    // do not include the file app.js in all your pages.
    // Find the module and paste the source here to keep the pages
    // lightweight and separated from the application source
    // !! Or even better use gulpfile.js to add modules for pages !!
    // ----------------------------------------------------------



  }); // end document ready


  // keeps the wrapper covering always the entire body
  function adjustPageLayout() {
    $('.page-wrapper').css('min-height', $(window).height());
  }

}(jQuery, window, document));
