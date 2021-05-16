var actions = {
    loadtypings: function (toload) {

        if (toload) {

            var ca = document.getElementById('campaign')
            var ty = document.getElementById("typing")
            var js = null
            $.ajax({
                type: "POST",
                url: '/Typing/GetTypings',
                data: ({ campaign: parseInt(ca.options[ca.selectedIndex].value) }),
                dataType: "html",
                async: false,
                success: function (data) {
                    js = data
                },
                error: function (data) {
                    alert(data.responseText);
                }
            })

            js = JSON.parse(js)
            var length = ty.options.length;
            for (i = length - 1; i >= 0; i--) {
                if (ty.options[i].value != 0) {
                    ty.options[i] = null;
                }
            }



            for (let i = 0; i < js.length; i++) {
                var opt = document.createElement('option')
                opt.appendChild(document.createTextNode(js[i].TypingName))
                opt.value = js[i].TypingId
                ty.appendChild(opt)
            }
        } else {
            var e = document.getElementById('typing')
            var h = document.getElementById("productdiv")
            if (e.options[e.selectedIndex].text.split('- ')[1] === 'Venta') {

                h.style.visibility = 'visible'
            } else {
                if (h.style.visibility === 'visible') {
                    h.style.visibility = 'hidden'
                }
            }
        }



    },


    loadoptions: function (optionid) {
        var ty = document.getElementById("options")
        var js = null
        $.ajax({
            type: "POST",
            url: '/Reporting/GetOptions',
            data: ({ option: parseInt(optionid) }),
            dataType: "html",
            async: false,
            success: function (data) {
                js = data
            },
            error: function (data) {
                alert(data.responseText);
            }
        })

        js = JSON.parse(js)
        var length = ty.options.length;
        for (i = length - 1; i >= 1; i--) {
            if (ty.options[i].value != 0) {
                ty.options[i] = null;
            }
        }


        if (parseInt(optionid) == 0) {
            for (let i = 0; i < js.length; i++) {
                var opt = document.createElement('option')
                opt.appendChild(document.createTextNode(js[i].Text))
                opt.value = js[i].Valuex
                ty.appendChild(opt)
            }
        } else {

            for (let i = 0; i < js.length; i++) {
                var opt = document.createElement('option')
                opt.appendChild(document.createTextNode(js[i].Text))
                opt.value = js[i].Valuet
                ty.appendChild(opt)
            }
        }


    },


    message: function (title, message) {

        var mt = document.getElementById('mtitle')
        mt.innerHTML = title

        var mm = document.getElementById('mmessage')
        mm.innerHTML = message

        $('#myModal').modal('show')




    },



}