﻿(function ($) {

     $("form").submit(function(e) {
         e.preventDefault();

         if (!$(e.currentTarget).valid()) {
             return;
         }

         var input = $(e.currentTarget).serializeFormToObject();

         abp.notify.success("Settings saved.");
/*
         _profileService.update(
             input
         ).then(function (result) {
             abp.notify.success(l("PersonalSettingsSaved"));
         });
*/
     });
 })(jQuery);