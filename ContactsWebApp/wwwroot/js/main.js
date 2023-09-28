const { remote } = require('electron');

function closeWindow() {
	const win = remote.getCurrentWindow();
	win.close();
}

function minimizeWindow() {
	const win = remote.getCurrentWindow();
	win.minimize();
}

function maximizeWindow() {
	const win = remote.getCurrentWindow();
	win.isMaximized() ? win.unmaximize() : win.maximize();
}