﻿(function ($) {

     var service = abp.settingManagement.mvc.uI.settingManagementUI.settingManagementUI;
     var l = abp.localization.getResource('AbpSettingManagementMvcUI');

     $("form").submit(function (e) {
         e.preventDefault();

         if (!$(e.currentTarget).valid()) {
             return;
         }

         var input = $(e.currentTarget).serializeFormToObject();
         abp.log.info(input);
         service.setSettingValues(input)
             .then(function (result) {
                 abp.notify.success(l("SuccessfullySaved"));
             });
     });
 })(jQuery);