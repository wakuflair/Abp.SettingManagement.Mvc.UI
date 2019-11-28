﻿(function ($) {

     var service = abp.settingManagement.mvc.uI.settingManagementUI.settingManagementUI;

     $("form").submit(function (e) {
         e.preventDefault();

         if (!$(e.currentTarget).valid()) {
             return;
         }

         var input = $(e.currentTarget).serializeFormToObject();
         service.setSettingValues(input)
             .then(function (result) {
                 abp.notify.success("Settings saved.");
             });
     });
 })(jQuery);