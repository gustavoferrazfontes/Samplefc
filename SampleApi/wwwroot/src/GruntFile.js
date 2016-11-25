/// <reference path="public/dev/pages/account/SignIn.html" />
/// <reference path="public/dev/pages/account/login.html" />
/// <reference path="public/dev/pages/account/login.html" />
/// <reference path="public/dev/pages/account/login.html" />
module.exports = function (grunt) {
    grunt.initConfig({
        cssmin: {
            sitecss: {
                files: {
                    'public/dist/assets/css/styles-1.0.0.min.css': [
                        'bower_components/bootswatch/superhero/bootstrap.css',
                        'bower_components/animate.css/animate.css',
                        'bower_components/font-awesome/css/font-awesome.css',
                        'bower_components/toastr/toastr.css',
                        'bower_components/angular-loading-bar/build/loading-bar.css'
                    ]
                }
            }
        },
        uglify: {
            options: {
                compress: true
            },
            applib: {
                src:
                    [
                        'bower_components/jquery/dist/jquery.js',
                        'bower_components/bootstrap/dist/js/bootstrap.js',
                        'bower_components/toastr/toastr.js',
                        'bower_components/angular/angular.js',
                        'bower_components/angular-route/angular-route.js',
                        'bower_components/angular-loading-bar/build/loading-bar.min.js',
                        'app/app.js',
                        'app/routes.js',
                        'app/config.js',
                        'app/factories/account-factory.js',
                        'app/factories/product-factory.js',
                        'app/factories/interceptors-factory.js',
                        'app/controllers/login-controller.js',
                        'app/controllers/logout-controller.js',
                        'app/controllers/signIn-controller.js',
                        'app/controllers/product-controller.js',
                        'app/directives/confirm-password-directive.js"'
                    ]
                , dest: 'public/dist/assets/js/scripts-1.0.0.min.js'
            }
        },
        copy: {
            main: {
                files: [
                    {
                        expand: true,
                        cwd: 'bower_components/font-awesome/fonts/',
                        src: '**',
                        dest: 'public/dist/assets/fonts',
                        flatten: false
                    },
                    {
                        expand: true,
                        cwd: 'bower_components/bootstrap/fonts/',
                        src: '**',
                        dest: 'public/dist/assets/fonts',
                        flatten: false
                    }
                ]
            }
        },
        htmlmin: {
            dist: {
                options: {
                    removeComments: true,
                    collapseWhitespace: true
                },
                files: {
                    'public/dist/pages/account/login.html': 'public/dev/pages/account/login.html',
                    'public/dist/pages/account/signIn.html': 'public/dev/pages/account/signIn.html',
                    'public/dist/pages/product/Index.html': 'public/dev/pages/product/Index.html',
                    'public/dist/pages/shared/headbar.html': 'public/dev/pages/shared/headbar.html',
             
                }
            }
        }

    });

    grunt.registerTask("dist", [
        'cssmin',
        'uglify',
        'copy',
        'htmlmin'
    ]);


    grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-contrib-htmlmin');
};
