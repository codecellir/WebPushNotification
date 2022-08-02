// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function browserNotify(data)
{
    if (!("Notification" in window))
    {
        alert(data.title);
    }

    var option = {
        body: data.title,
        dir: "rtl",
        icon: '/logo.webp'
    };

    if (Notification.permission == "granted")
    {
        var notification = new Notification('کدسل', option);

        notification.onclick = function (event)
        {
            event.preventDefault;
            window.location.href = data.url;
            notification.close();
        }
    }
    else if (Notification.permission != "granted")
    {
        Notification.requestPermission().then(function (permission)
        {
            if (permission == "granted")
            {
                var notification = new Notification('کدسل', option);

                notification.onclick = function (event)
                {
                    event.preventDefault;
                    window.location.href = data.url;
                    notification.close();
                }
            }
        });
    }
}