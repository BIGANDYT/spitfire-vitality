(function($) {
    $(".owl-carousel6-brands").owlCarousel({
        pagination: false,
        navigation: true,
        items: 6,
        addClassActive: true,
        itemsCustom: [
            [0, 1],
            [320, 1],
            [480, 2],
            [700, 3],
            [975, 5],
            [1200, 6],
            [1400, 6],
            [1600, 6]
        ],
    });

    $(".owl-carousel5").owlCarousel({
        pagination: false,
        navigation: true,
        items: 5,
        addClassActive: true,
        itemsCustom: [
            [0, 1],
            [320, 1],
            [480, 2],
            [660, 2],
            [700, 3],
            [768, 3],
            [992, 4],
            [1024, 4],
            [1200, 5],
            [1400, 5],
            [1600, 5]
        ],
    });

    $(".owl-carousel4").owlCarousel({
        pagination: false,
        navigation: true,
        items: 4,
        addClassActive: true,
    });

    $(".owl-carousel3").owlCarousel({
        pagination: false,
        navigation: true,
        items: 3,
        addClassActive: true,
        itemsCustom: [
            [0, 1],
            [320, 1],
            [480, 2],
            [700, 3],
            [768, 2],
            [1024, 3],
            [1200, 3],
            [1400, 3],
            [1600, 3]
        ],
    });

    $(".owl-carousel2").owlCarousel({
        pagination: false,
        navigation: true,
        items: 2,
        addClassActive: true,
        itemsCustom: [
            [0, 1],
            [320, 1],
            [480, 2],
            [700, 3],
            [975, 2],
            [1200, 2],
            [1400, 2],
            [1600, 2]
        ],
    });
})(jQuery2);