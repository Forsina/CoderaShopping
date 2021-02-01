angular.module("codera.shopping")

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
                templateUrl: "app/categories/category-view.html",
                controller: 'CategoryController'
            },
            {
                name: 'products',
                url: '/products',
                templateUrl: "app/products/product-view.html",
                controller: 'ProductController'
            }

        ];
        states.forEach((state) => $stateProvider.state(state));
        //$urlRouterProvider.otherwise('/');
    });