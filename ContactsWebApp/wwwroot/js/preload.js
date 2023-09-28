window.nodeRequire = require; // Сохранение функции require в глобальной переменной
delete window.require; // Удаление стандартной функции require
delete window.exports; // Удаление стандартной переменной exports
delete window.module; // Удаление стандартного модуля module