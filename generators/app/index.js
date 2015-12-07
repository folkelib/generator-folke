'use strict';
var yeoman = require('yeoman-generator');
var chalk = require('chalk');
var yosay = require('yosay');
var mkdirp = require('mkdirp');

module.exports = yeoman.generators.Base.extend({
  prompting: function () {
    //var done = this.async();

    // Have Yeoman greet the user.
    this.log(yosay(
      'Welcome to the unreal ' + chalk.red('generator-folke') + ' generator!'
    ));

    /*this.prompt({
      type: 'input',
      name: 'name',
      message: 'Your project name (directory will be created)',
      default: this.appname.replace(' ', '')
    }, function (answers){
      this.log(answers.name);
      this.name = answers.name;
      done();
    }.bind(this));*/
  },

  writing: function () {
    this.fs.copyTpl(
      this.templatePath('**/*'),
      this.destinationPath(''), {
        name: this.appname
      }
    );
    this.fs.copy(this.templatePath('.bowerrc'), this.destinationPath('.bowerrc'));
    mkdirp.sync(this.destinationPath('wwwroot'));
    mkdirp.sync(this.destinationPath('src/services'));
  },

  install: function () {
    this.installDependencies();
    this.spawnCommand('tsd', ['install']);
  }
});
