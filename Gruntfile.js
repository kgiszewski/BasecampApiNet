module.exports = function(grunt) {
  require('load-grunt-tasks')(grunt);
  var path = require('path')

  grunt.initConfig({
    pkg: grunt.file.readJSON('package.json'),
    pkgMeta: grunt.file.readJSON('config/meta.json'),
    dest: grunt.option('target') || 'dist',
    basePath: path.join('<%= dest %><%= pkgMeta.name %>'),

    watch: {
      options: {
        spawn: false,
        atBegin: true
      }
    },

    copy: {
      dll: {
        cwd: 'src/BasecampApiNet/bin/Debug/',
        src: 'BasecampApiNet.dll',
        dest: '<%= dest %>/bin/',
        expand: true
      }
    },

    clean: {
      build: '<%= grunt.config("basePath").substring(0, 4) == "dist" ? "dist/**/*" : "null" %>',
      tmp: ['tmp']
    },

    assemblyinfo: {
      options: {
        files: ['src/BasecampApiNet/BasecampApiNet.csproj'],
        filename: 'AssemblyInfo.cs',
        info: {
          version: '<%= (pkgMeta.version.indexOf("-") > 0 ? pkgMeta.version.substring(0, pkgMeta.version.indexOf("-")) : pkgMeta.version) %>', 
          fileVersion: '<%= pkgMeta.version %>'
        }
      }
    },

    touch: {
      webconfig: {
        src: ['<%= grunt.option("target") %>\\Web.config']
      }
    },

    msbuild: {
      options: {
        stdout: true,
        verbosity: 'quiet',
        maxCpuCount: 4,
		version: 4.0,
        buildParameters: {
          WarningLevel: 2,
          NoWarn: 1607
        }
      },
      dist: {
        src: ['src/BasecampApiNet/BasecampApiNet.csproj'],
        options: {
          projectConfiguration: 'Debug',
          targets: ['Clean', 'Rebuild'],
        }
      }
    }
  });

  grunt.registerTask('default', ['clean', 'assemblyinfo', 'msbuild:dist', 'copy:dll']);
};