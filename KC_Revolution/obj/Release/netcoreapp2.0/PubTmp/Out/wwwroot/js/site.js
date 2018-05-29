// Write your JavaScript code.
$(document).ready(function() {

    "use strict";
    var height = 0;
    var equal_height_rows = document.getElementsByClassName("equal_height");
    for (var x = 0; x < equal_height_rows.length; x++) {
        var row = equal_height_rows[x];
        for (var y = 0; y < row.children.length; y++) {
            //I like to nest my pods inside the columns
            var child = row.children[y].children[0],
                child_height = child.getBoundingClientRect().height;
            if (child_height > height)
                height = child_height;   
        }
        for (var y = 0; y < row.children.length; y++) {
            var col = row.children[y].children[0];
            if (col.nodeName == "DIV")
                col.style.height = height + "px";
        }
        
    }

});