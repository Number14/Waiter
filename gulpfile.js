'use strict';

const gulp = require('gulp');
const { restore, build, test, pack, publish } = require('gulp-dotnet-cli');
const args = require('yargs').argv;
const fs = require('fs');


const project = JSON.parse(fs.readFileSync("./package.json"));
const configuration = args.mode || "Debug";

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