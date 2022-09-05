import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})

export class Utils {

  public readonly baseUrl:string = "http://localhost:18250/";
  //loadAPI!: Promise<any>;

  public loadFormScript() {
      var isFound = false;
      var scripts = document.getElementsByTagName("script")
      for (var i = 0; i < scripts.length; ++i) {
        if (scripts[i].getAttribute('src') != null && scripts[i].getAttribute('src')!.includes("loader")) {
          isFound = true;
        }
      }

      if (!isFound) {
        var dynamicScripts = [
            "./assets/admin/assets/vendor/jquery-validation/jquery.validate.min.js",
            "./assets/admin/assets/js/plugins-init/jquery.validate-init.js"
        ];

        for (var i = 0; i < dynamicScripts.length; i++) {
          let node = document.createElement('script');
          node.src = dynamicScripts[i];
          node.async = false;
          document.getElementsByTagName('body')[0].appendChild(node);
        }

      }
  }


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
        "./assets/admin/assets/vendor/chart.js/Chart.bundle.min.js",
        "./assets/admin/assets/vendor/owl-carousel/owl.carousel.js",
        "./assets/admin/assets/vendor/peity/jquery.peity.min.js",
        "./assets/admin/assets/vendor/apexchart/apexchart.js",
        "./assets/admin/assets/js/dashboard/dashboard-1.js"
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



  public loadTablesScript() {
      var isFound = false;
      var scripts = document.getElementsByTagName("script")
      for (var i = 0; i < scripts.length; ++i) {
        if (scripts[i].getAttribute('src') != null && scripts[i].getAttribute('src')!.includes("loader")) {
          isFound = true;
        }
      }

      if (!isFound) {
        var dynamicScripts = [
          "./assets/admin/assets/vendor/datatables/js/jquery.dataTables.min.js",
          "./assets/admin/assets/js/plugins-init/datatables.init.js"
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

}
