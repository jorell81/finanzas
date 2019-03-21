(function() {
    new Vue({
        el: "#init",
        data: {
            name: "a",
            user: "",
            password: ""
        },
        methods: {
            Login: function() {
                _Request(
                    '__ClAS95dOSvCL',
                    'Login', {
                        user: this.user,
                        password: this.password
                    },
                    function(response) {
                        if (response) { location.href = "../Home" }
                    },
                    function(error) {
                        console.log('Error:', error)
                    },
                    undefined,
                    2
                );
            }
        },
        mounted: function() {
            document.getElementById("init").style.display = "";
            document.getElementById('mayus').style.visibility = 'hidden';
        },
    });
})();