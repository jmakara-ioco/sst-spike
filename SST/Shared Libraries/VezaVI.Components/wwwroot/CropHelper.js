// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API
function getWidthHeight() {
    var a = [];
    var e = document.getElementById("blazor_cropper");
    if (e != null) {
        a.push(e.clientWidth);
        a.push(e.clientHeight);
    }
    return a;
}

function getOriImgSize(){
    var a = [];
    var e = document.getElementById("oriimg");
    a.push(e.naturalWidth);
    a.push(e.naturalHeight);
    return a;
}

async function cropAsync(id, sx, sy, swidth, sheight, x, y, width, height, format) {
    var blob =  await new Promise(function (resolve) {
        var canvas = document.createElement('canvas');
        var img = document.getElementById(id);
        canvas.width = width;
        canvas.height = height;
        canvas.getContext('2d').drawImage(img, sx, sy, swidth, sheight, x, y, width, height);
        resolve(canvas.toDataURL(format));
    })
    return blob;
}

function setImg(id) {
    var e = document.getElementById("blazor_cropper");
    e.parentElement.style.overflowX='hidden';
    var input = document.getElementById(id);
    
    if (input.files[0] != undefined) {
        let fileToBlob = async (file) => new Blob([new Uint8Array(await input.files[0].arrayBuffer())], { type: input.files[0].type });
        var dimg = document.getElementById('dimg');
        dimg.setAttribute('src', fileToBlob);
        var oriimg = document.getElementById('oriimg');
        oriimg.setAttribute('src', fileToBlob);
    }
    //var src = URL.createObjectURL(input.files[0]);
    //var src = input.files[0];

    //var dimg = document.getElementById('dimg');
    //console.log(dimg);
    //if ('srcObject' in dimg) {
    //    dimg.srcObject = src;
    //} else {
        // Avoid using this in new browsers, as it is going away.
    //    dimg.src = URL.createObjectURL(src);
    //}

    //var oriimg = document.getElementById('oriimg');
    //if ('srcObject' in oriimg) {
    //    oriimg.srcObject = src;
    //} else {
        // Avoid using this in new browsers, as it is going away.
    //    oriimg.src = URL.createObjectURL(src);
    //}

//document.getElementById('dimg').setAttribute('src', input.files[0]);
//document.getElementById('oriimg').setAttribute('src', input.files[0]);
    
}



window.addEventListener('resize', (ev) => {
    DotNet.invokeMethodAsync('VezaVI.Light.Components', 'SetWidthHeight');
})

var serializeEvent = function (e) {
    if (e) {
        var o = {
            altKey: e.altKey,
            button: e.button,
            buttons: e.buttons,
            clientX: e.clientX,
            clientY: e.clientY,
            ctrlKey: e.ctrlKey,
            metaKey: e.metaKey,
            movementX: e.movementX,
            movementY: e.movementY,
            offsetX: e.offsetX,
            offsetY: e.offsetY,
            pageX: e.pageX,
            pageY: e.pageY,
            screenX: e.screenX,
            screenY: e.screenY,
            shiftKey: e.shiftKey
        };
        return o;
    }
};

document.getElementById("blazor_cropper").addEventListener('mousemove', (ev) => {
    try {
        DotNet.invokeMethodAsync('VezaVI.Light.Components', 'OnMouseMove', serializeEvent(ev));
    }
    catch (ex) {
        console.log(ex);
    }
});

document.getElementById("blazor_cropper").addEventListener('mouseup', (ev) => {
    try {
        DotNet.invokeMethodAsync('VezaVI.Light.Components', 'OnMouseUp', serializeEvent(ev));
    }
    catch (ex) {
        console.log(ex);
    }
});

document.getElementById("blazor_cropper").addEventListener('touchmove', (ev) => {
    try {
        DotNet.invokeMethodAsync('VezaVI.Light.Components', 'OnTouchMove', {
            clientX: ev.touches[0].clientX,
            clientY: ev.touches[0].clientY
        });
    }
    catch (ex) {
        console.log(ex);
    }
});

document.getElementById("blazor_cropper").addEventListener('touchend', (ev) => {
    try {
        DotNet.invokeMethodAsync('VezaVI.Light.Components', 'OnTouchEnd');
    }
    catch (ex) {
        console.log(ex);
    }
});
