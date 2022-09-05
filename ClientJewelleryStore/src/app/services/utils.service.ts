import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})

export class Utils {
  loadFormScript() {
    throw new Error('Method not implemented.');
  }

  public readonly baseUrl:string = "http://localhost:18250/";
  loadAPI!: Promise<any>;

  // public loadFormScript() {
  //     var isFound = false;
  //     var scripts = document.getElementsByTagName("script")
  //     for (var i = 0; i < scripts.length; ++i) {
  //       if (scripts[i].getAttribute('src') != null && scripts[i].getAttribute('src')!.includes("loader")) {
  //         isFound = true;
  //       }
  //     }

  //     if (!isFound) {
  //       var dynamicScripts = [
  //         "/assets/admin_assets/app-assets/vendors/js/forms/spinner/jquery.bootstrap-touchspin.js",
  //         "/assets/admin_assets/app-assets/vendors/js/forms/validation/jqBootstrapValidation.js",
  //         "/assets/admin_assets/app-assets/vendors/js/forms/icheck/icheck.min.js",
  //         "/assets/admin_assets/app-assets/vendors/js/forms/toggle/bootstrap-switch.min.js",
  //         "/assets/admin_assets/app-assets/vendors/js/forms/toggle/switchery.min.js",
  //         "/assets/admin_assets/app-assets/js/core/app-menu.js",
  //         "/assets/admin_assets/app-assets/js/core/app.js",
  //         "/assets/admin_assets/app-assets/js/scripts/forms/validation/form-validation.js",
  //       ];

  //       for (var i = 0; i < dynamicScripts.length; i++) {
  //         let node = document.createElement('script');
  //         node.src = dynamicScripts[i];
  //         node.async = false;
  //         document.getElementsByTagName('body')[0].appendChild(node);
  //       }

  //     }
  // }






  public loadIndexScript() {

    var isFound = false;
    var scripts = document.getElementsByTagName("script")
    for (var i = 0; i < scripts.length; ++i) {
      if (scripts[i].getAttribute('src') != null && scripts[i].getAttribute('src')!.includes("loader")) {
        isFound = true;
      }
    }

    if (!isFound) {
      var dynamicScripts = [
        "assets/client/assets/js/plugins.js",
        "assets/client/assets/js/main.js"

      ];

      for (var i = 0; i < dynamicScripts.length; i++) {
        let node = document.createElement('script');
        node.src = dynamicScripts[i];
        node.async = false;
        node.innerHTML = '';
        node.defer = true;
        document.getElementsByTagName('body')[0].appendChild(node);
      }

    }

  }



  // public loadTablesScript() {
  //     var isFound = false;
  //     var scripts = document.getElementsByTagName("script")
  //     for (var i = 0; i < scripts.length; ++i) {
  //       if (scripts[i].getAttribute('src') != null && scripts[i].getAttribute('src')!.includes("loader")) {
  //         isFound = true;
  //       }
  //     }

  //     if (!isFound) {
  //       var dynamicScripts = [
  //         "/assets/admin_assets/app-assets/vendors/js/tables/datatable/datatables.min.js",
  //         "/assets/admin_assets/app-assets/vendors/js/tables/datatable/dataTables.buttons.min.js",
  //         "/assets/admin_assets/app-assets/vendors/js/tables/buttons.flash.min.js",
  //         "/assets/admin_assets/app-assets/vendors/js/tables/jszip.min.js",
  //         "/assets/admin_assets/app-assets/vendors/js/tables/pdfmake.min.js",
  //         "/assets/admin_assets/app-assets/vendors/js/tables/vfs_fonts.js",
  //         "/assets/admin_assets/app-assets/vendors/js/tables/buttons.html5.min.js",
  //         "/assets/admin_assets/app-assets/vendors/js/tables/buttons.print.min.js",
  //         "/assets/admin_assets/app-assets/js/core/app-menu.js",
  //         "/assets/admin_assets/app-assets/js/core/app.js",
  //         "/assets/admin_assets/app-assets/js/scripts/tables/datatables/datatable-advanced.js"
  //       ];

  //       for (var i = 0; i < dynamicScripts.length; i++) {
  //         let node = document.createElement('script');
  //         node.src = dynamicScripts[i];
  //         node.async = false;
  //         node.innerHTML = '';
  //         node.defer = true;
  //         document.getElementsByTagName('body')[0].appendChild(node);
  //       }

  //     }
  // }

}
