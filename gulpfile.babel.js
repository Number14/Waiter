'use strict';

import gulp from 'gulp';
import { restore, build, test, pack, publish } from 'gulp-dotnet-cli';
import yargs from 'yargs';
import fs from 'fs';

const args = yargs.argv;

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