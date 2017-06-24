"use strict"

let gulp = require('gulp');
let { restore, build, test, pack, publish } = require('gulp-dotnet-cli');
let args = require('yargs').argv;
let fs = require('fs');

let project = JSON.parse(fs.readFileSync("./package.json"));
let configuration = args.mode || "Debug";

gulp.task('restore', () => {
    return gulp.src('**/*.sln', { read: false })
        .pipe(restore());
});

gulp.task('build', ['restore'], () => {
    return gulp.src('**/*.sln', { read: false })
        .pipe(build({version: project.version, configuration: configuration}));
});

gulp.task('test', ['restore', 'build'], () => {
    return gulp.src('**/*.Tests.csproj')
        .pipe(test());
});

gulp.task('default', ['restore', 'build', 'test']);