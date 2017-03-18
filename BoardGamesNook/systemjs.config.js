(function(global) {

  // map tells the System loader where to look for things
var map = {
    //new
    'ng-loader': './systemjs-angular-loader.js',
    'app': 'app',

    'rxjs':                       'node_modules/rxjs',
    'angular2-in-memory-web-api': 'node_modules/angular2-in-memory-web-api',
    '@angular': 'node_modules/@angular',
    //new
    'ts':                        'npm:plugin-typescript@5.2.7/lib/plugin.js',
    'typescript':                'npm:typescript@2.0.10/lib/typescript.js'
  };

  // packages tells the System loader how to load when no filename and/or no extension
  var packages = {
      //'app':                        { main: 'bootgamer.js',  defaultExtension: 'js' },
    //'rxjs':                       { defaultExtension: 'js' },
    //'angular2-in-memory-web-api': { defaultExtension: 'js' },

    app: {
        main: './main.ts',
        defaultExtension: 'ts',
        meta: {
            './*.ts': {
                loader: 'ng-loader'
            }
        }
    },
    rxjs: {
        defaultExtension: 'js'
    }
  };

  var packageNames = [
    '@angular/common',
    '@angular/compiler',
    '@angular/core',
    '@angular/http',
    '@angular/platform-browser',
    '@angular/platform-browser-dynamic',
    '@angular/router',
    //'@angular/router-deprecated',
    //'@angular/testing',
    '@angular/upgrade',
    //new
    '@angular/upgrade/static',
    '@angular/router/upgrade',
    '@angular/forms'
  ];

  // add package entries for angular packages in the form '@angular/common': { main: 'index.js', defaultExtension: 'js' }
  packageNames.forEach(function(pkgName) {
    packages[pkgName] = { main: 'index.js', defaultExtension: 'js' };
  });

  var config = {
    map: map,
    packages: packages
  }

  System.config(config);

})(this);    