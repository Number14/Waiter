let gulp = require("gulp");
let { restore, build, test, pack, publish } = require('gulp-dotnet-cli');

gulp.task('restore', () => {
    return gulp.src('**/*.sln', { read: false })
        .pipe(restore());
});

gulp.task('build', ['restore'], () => {
    return gulp.src('**/*.sln', { read: false })
        .pipe(build());
});

gulp.task('test', ['restore', 'build'], () => {
    return gulp.src('**/*.Tests.csproj')
        .pipe(test());
});

gulp.task('default', ['restore', 'build', 'test']);