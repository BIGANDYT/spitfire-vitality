AmCharts.makeChart("chartdiv1",
    {
        "type": "pie",
        "path": "https://www.amcharts.com/lib/3/",
        "labelText": "[[title]]",
        "labelRadius": 5,
        "radius": 75,
        "sequencedAnimation": false,
        "startDuration": 0,
        "titleField": "category",
        "valueField": "column-1",
        "marginBottom": 0,
        "marginTop": 0,
        "fontSize": 10,
        "theme": "light",
        "allLabels": [],
        "balloon": {},
        "titles": [
            {
                "id": "Title-1",
                "text": "Site Interest"
            }
        ],
        "dataProvider": [
            {
                "category": "Mobile",
                "column-1": 8
            },
            {
                "category": "Surface",
                "column-1": 6
            },
            {
                "category": "Office",
                "column-1": 2
            },
            {
                "category": "Xbox",
                "column-1": "2"
            }
        ]
    }
);

AmCharts.makeChart("chartdiv2",
    {
        "type": "pie",
        "path": "https://www.amcharts.com/lib/3/",
        "labelText": "[[title]]",
        "labelRadius": 5,
        "radius": 75,
        "sequencedAnimation": false,
        "startDuration": 0,
        "titleField": "category",
        "valueField": "column-1",
        "marginBottom": 0,
        "marginTop": 0,
        "fontSize": 10,
        "theme": "light",
        "allLabels": [],
        "balloon": {},
        "titles": [
            {
                "id": "Title-1",
                "text": "Gaming Interest"
            }
        ],
        "dataProvider": [
            {
                "category": "Action",
                "column-1": 8
            },
            {
                "category": "Adventure",
                "column-1": 6
            },
            {
                "category": "Fighting",
                "column-1": 2
            },
            {
                "category": "Racing",
                "column-1": "2"
            },
            {
                "category": "Sports",
                "column-1": "3"
            }
        ]
    }
);

(function($) {
    $(document).ready(function() {
        var panel = $('.color-panel');

        // handle theme colors
        var setColor = function(color) {
            $('#style-color').attr("href", "../../assets/frontend/layout/css/themes/" + color + ".css");
            $('.corporate .site-logo img').attr("src", "../../assets/frontend/layout/img/logos/logo-corp-" + color + ".png");
            $('.ecommerce .site-logo img').attr("src", "../../assets/frontend/layout/img/logos/logo-shop-" + color + ".png");
        }

        $('.icon-color', panel).click(function() {
            $('.color-mode').show();
            $('.icon-color-close').show();
        });

        $('.icon-color-close', panel).click(function() {
            $('.color-mode').hide();
            $('.icon-color-close').hide();
        });

        $('li', panel).click(function() {
            var color = $(this).attr("data-style");
            setColor(color);
            $('.inline li', panel).removeClass("current");
            $(this).addClass("current");
        });
    });
})(jQuery2);