angular.module("codera.shopping")
    //.config(function ($stateProvider, $urlRouterProvider) {
    //    $urlRouterProvider.otherwise("/home");
    //    //todo: define ur states here

    //    $stateProvider.state('/users', {
    //        url: "/users",
    //        templateUrl: "app/users/UserView.html",
    //        controller: 'UserController'
    //    })
    .config(function ($stateProvider, $urlRouterProvider) {
        var states = [
            {
                name: 'main',
                url: '',
                template: '<h1>This is Main</h1>'
            },
            {
                name: 'users',
                url: '/users',
                templateUrl: "app/users/user-view.html",
                controller: 'UserController'
            },
            {
                name: 'categories',
                url: '/categories',
                templateUrl: "app/categories/CategoryView.html",
                controller: 'CategoryController'
            },
            {
                name: 'products',
                url: '/products',
                templateUrl: "app/products/ProductView.html",
                controller: 'ProductController'
            }

        ];
        states.forEach((state) => $stateProvider.state(state));
        //$urlRouterProvider.otherwise('/');
    });