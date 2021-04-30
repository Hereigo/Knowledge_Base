/// <binding BeforeBuild='clean, min' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify");

var cssBoots = "./node_modules/bootstrap/dist/css/bootstrap.min.css";

var jsJqry = "./node_modules/jquery/dist/jquery.min.js";
var jsJqVa = "./node_modules/jquery-validation/dist/jquery.validate.min.js";
var jsJqUn = "./node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js";
var jsBoots = "./node_modules/bootstrap/dist/js/bootstrap.bundle.min.js";

var bundledJs = "./wwwroot/js/site.min.js";
var bundledCss = "./wwwroot/css/site.min.css";

gulp.task("clean:js", function (cb) {
    rimraf(bundledJs, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(bundledCss, cb);
});

gulp.task("clean", gulp.series(["clean:js", "clean:css"]));

gulp.task("min:js", function () {
    return gulp.src([jsJqry, jsJqVa, jsJqUn, jsBoots], { base: "." })
        .pipe(concat(bundledJs))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    return gulp.src([cssBoots])
        .pipe(concat(bundledCss))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("min", gulp.series(["min:js", "min:css"]));
