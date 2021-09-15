function getOrientation(file, callback) {
    var reader = new FileReader();

    reader.onload = function (event) {
        var view = new DataView(event.target.result);

        if (view.getUint16(0, false) != 0xFFD8) return callback(-2);

        var length = view.byteLength,
            offset = 2;

        while (offset < length) {
            var marker = view.getUint16(offset, false);
            offset += 2;

            if (marker == 0xFFE1) {
                if (view.getUint32(offset += 2, false) != 0x45786966) {
                    return callback(-1);
                }
                var little = view.getUint16(offset += 6, false) == 0x4949;
                offset += view.getUint32(offset + 4, little);
                var tags = view.getUint16(offset, little);
                offset += 2;

                for (var i = 0; i < tags; i++)
                    if (view.getUint16(offset + (i * 12), little) == 0x0112)
                        return callback(view.getUint16(offset + (i * 12) + 8, little));
            }
            else if ((marker & 0xFF00) != 0xFF00) break;
            else offset += view.getUint16(offset, false);
        }
        return callback(-1);
    };

    reader.readAsArrayBuffer(file.slice(0, 64 * 1024));
};

//new functions for exif orientation

function resetOrientation(srcBase64, orientation) {
    // var img = new Image();       

    // transform context before drawing image
    switch (orientation) {
        case 8:
            //ctx.rotate(90*Math.PI/180);
            rotate($('#imgProfile'), 90 * Math.PI / 180)
            break;
        case 3:
            // ctx.rotate(180*Math.PI/180);
            rotate($('#imgProfile'), 180 * Math.PI / 180)
            break;
        case 6:
            //ctx.rotate(-90*Math.PI/180);
            rotate($('#imgProfile'), 90)
            break;
    };
};

function rotate(ele, degrees) {
    if (degrees != 90) return false;
    ele.css({
        '-webkit-transform': 'rotate(' + degrees + 'deg)',
        '-moz-transform': 'rotate(' + degrees + 'deg)',
        '-ms-transform': 'rotate(' + degrees + 'deg)',
        '-o-transform': 'rotate(' + degrees + 'deg)',
        'transform': 'rotate(' + degrees + 'deg)'
    });
}