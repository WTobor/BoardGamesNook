'use strict';
var gulp = require('gulp'),
    deletefile = require('gulp-delete-file');
gulp.task('deletefile', function () {
    var regexp = /\w*(\-\w{8}\.js){1}$|\w*(\-\w{8}\.js.map){1}$/;
    gulp.src([
        './app/*.js',
        './app/*.js.map',
        './app/**/*.js',
        './app/**/*.js.map',
        './app/**/**/*.js',
        './app/**/**/*.js.map'
    ]).pipe(deletefile({
        reg: regexp,
        deleteMatch: false
    }));
});