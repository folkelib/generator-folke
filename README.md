# generator-folke [![NPM version][npm-image]][npm-url] [![Build Status][travis-image]][travis-url] [![Dependency Status][daviddm-image]][daviddm-url] [![Coverage percentage][coveralls-image]][coveralls-url]
> Creates an SPA based on the Folke libraries. This generator is *in developement* and should be used only if you are interrested in contributing to the project.

## Installation

First, install [Yeoman](http://yeoman.io) and generator-folke using [npm](https://www.npmjs.com/) (we assume you have pre-installed [node.js](https://nodejs.org/)).

```bash
npm install -g yo
npm install -g generator-folke
```

You also need Typescript and the Typescript definitions:
```bash
npm install -g typescript
npm install -g tsd
```

Then generate your new project from an *empty* directory:

```bash
yo folke
```

The project name is the directory name, it should only have letters and
use camel casing.

## Usage

To compile the client:
```bash
gulp
```

To run the web site:
```bash
dnx web
```

The site is reachable at http://localhost:5000/

There is a debug version (the scripts are not optimized) that
is available at http://localhost:5000/debug.html

You should run `gulp watch` so that the Javascript and HTML files
are updated as you save them. It only works for the debug version of the
web site.

## Getting To Know Yeoman

Yeoman has a heart of gold. He&#39;s a person with feelings and opinions, but he&#39;s very easy to work with. If you think he&#39;s too opinionated, he can be easily convinced. Feel free to [learn more about him](http://yeoman.io/).

## License

MIT © [Sidoine De Wispelaere](https://sidoine.net)


[npm-image]: https://badge.fury.io/js/generator-folke.svg
[npm-url]: https://npmjs.org/package/generator-folke
[travis-image]: https://travis-ci.org/folkelib/generator-folke.svg?branch=master
[travis-url]: https://travis-ci.org/folkelib/generator-folke
[daviddm-image]: https://david-dm.org/folkelib/generator-folke.svg?theme=shields.io
[daviddm-url]: https://david-dm.org/folkelib/generator-folke
[coveralls-image]: https://coveralls.io/repos/folkelib/generator-folke/badge.svg
[coveralls-url]: https://coveralls.io/r/folkelib/generator-folke
