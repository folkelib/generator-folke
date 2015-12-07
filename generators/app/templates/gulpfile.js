var gulp = require("gulp"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    project = require("./project.json"),
    less = require('gulp-less'),
    rjs = require('gulp-requirejs-bundler'),
    htmlreplace = require('gulp-html-replace'),
    rename = require('gulp-rename'),
    typescript = require('gulp-typescript'),
    exec = require('child_process').exec;
    
var paths = {
    src: "./src/",
    webroot: "./" + project.webroot + "/"
};
paths.bower = [paths.src + 'bower_components/**/*.js', paths.src + 'bower_components/**/*.css', paths.src + 'bower_components/**/*.less',
    paths.src + 'bower_components/folke-identity/**/*.js' ];
paths.bowerDir = paths.webroot + "bower_components/";
paths.html = paths.src + '**/*.html';
paths.less = paths.src + "css/style.less";
paths.bowerTs = paths.src + "bower_components/**/*.ts";
paths.ts = paths.src + '**/*.ts';
paths.imagesDir = paths.webroot + "css/";
paths.images = [paths.src + 'css/**/*.png', paths.src + 'css/**/*.jpg', paths.src + 'css/**/*.svg', paths.src + 'images/*.*'];
paths.jsDir = paths.webroot;
paths.js = paths.jsDir + "**/*.js";
paths.minJs = paths.jsDir + "**/*.min.js";
paths.cssDir = paths.webroot + "css/";
paths.css = paths.cssDir + "**/*.css";

var requireJsOptimizerConfig = {
    mainConfigFile: paths.jsDir + 'app/require.config.js',
    out: 'scripts.js',
    baseUrl: paths.jsDir,
    name: 'app/startup',
    paths: {
        requireLib: 'bower_components/requirejs/require',
        stripe: 'empty:'
    },
    include: [
        'requireLib',
        'components/home/about',
        'components/home/home-page',
        // Put there any module that must be embedded in the main script        
    ],
    insertRequire: ['app/startup'],
    bundles: {
        // If you want parts of the site to load on demand, remove them from the 'include' list
        // above, and group them into bundles here.
        // 'bundle-name': [ 'some/module', 'another/module' ],
        // 'another-bundle-name': [ 'yet-another-module' ]
    },
    wrap: {
        end: 'require.config({paths: {stripe: "https://js.stripe.com/v2/?"}})'
    }
};


var tsProject = typescript.createProject('src/tsconfig.json');

gulp.task('default', ['build']);

gulp.task('build', ['index', 'requirejs', 'less', 'image', 'bower', 'webconfig']);

gulp.task('debug', ['html', 'ts', 'less', 'image', 'bower', 'webconfig']);

gulp.task('index', ['html'], function () {
    return gulp.src(paths.webroot + 'debug.html')
        .pipe(htmlreplace({
            'js': 'scripts.js'
        }))
        .pipe(rename('index.html'))
        .pipe(gulp.dest(paths.webroot));
});

gulp.task('webconfig', function () {
    return gulp.src('src/web.config').pipe(gulp.dest(paths.webroot));
});

gulp.task('bower', function () {
    return gulp.src(paths.bower).pipe(gulp.dest(paths.bowerDir));
});

gulp.task('watch', function () {
    gulp.watch(paths.images, ['image']);
    gulp.watch(paths.html, ['html']);
    gulp.watch([paths.ts, '!' + paths.bowerTs], ['ts']);
    gulp.watch(paths.src + "/**/*.less", ['less']);
    gulp.watch(paths.bowerTs, ['bowerts']);
});

gulp.task('less', function () {
    return gulp.src(paths.less).pipe(less()).pipe(gulp.dest(paths.cssDir));
});

gulp.task('ts', ['csts'], function () {
    var tsResult = gulp.src(paths.ts).pipe(typescript(tsProject));
    return tsResult.js.pipe(gulp.dest(paths.jsDir));
});

gulp.task('bowerts', function () {
    var tsResult = gulp.src([paths.bowerTs, 'src/references.d.ts']).pipe(typescript(tsProject));
    return tsResult.js.pipe(gulp.dest("src/bower_components")).pipe(gulp.dest(paths.jsDir + "/bower_components"));
});

gulp.task('image', function () {
    return gulp.src(paths.images).pipe(gulp.dest(paths.imagesDir));
});

gulp.task('html', function () {
    return gulp.src(paths.html).pipe(gulp.dest(paths.webroot));
});

gulp.task("requirejs", ['ts', 'bower'], function () {
    return rjs(requireJsOptimizerConfig)
        .pipe(uglify({ preserveComments: 'some' }))
        .pipe(gulp.dest(paths.webroot));
});

gulp.task("csts", function (cb) {
  exec('dnx csts', function (err, stdout, stderr) {
    console.log(stdout);
    console.log(stderr);
    cb(err);
    });
});