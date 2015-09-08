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
        dest: '<%= dest %>',
        expand: true
      },
      
      nuget: {
        files: [
          {
            cwd: '<%= dest %>',
            src: ['**/*', '!bin', '!bin/*'],
            dest: 'tmp/nuget/content',
            expand: true
          },
          {
            cwd: '<%= dest %>/bin',
            src: ['*.dll'],
            dest: 'tmp/nuget/lib/net40',
            expand: true
          }
        ]
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

    nugetpack: {
    	dist: {
    		src: 'tmp/nuget/package.nuspec',
    		dest: 'pkg'
    	}
    },

    template: {
    	'nuspec': {
			'options': {
    			'data': { 
            name: '<%= pkgMeta.name %>',
    				version: '<%= pkgMeta.version %>',
            url: '<%= pkgMeta.url %>',
            license: '<%= pkgMeta.license %>',
            licenseUrl: '<%= pkgMeta.licenseUrl %>',
            author: '<%= pkgMeta.author %>',
            authorUrl: '<%= pkgMeta.authorUrl %>',

    				files: [{ path: 'tmp/nuget/**', target: 'content/App_Plugins/Archetype'}]
	    		}
    		},
    		'files': { 
    			'tmp/nuget/package.nuspec': ['config/package.nuspec']
    		}
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
  grunt.registerTask('nuget',   ['clean:tmp', 'default', 'copy:nuget', 'template:nuspec', 'nugetpack', 'clean:tmp']);
};