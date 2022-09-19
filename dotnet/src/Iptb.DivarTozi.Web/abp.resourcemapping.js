module.exports = {
    aliases: {
        "@node_modules": "./node_modules",
        "@libs": "./wwwroot/libs"
    },
    clean: [
        "@libs",
        "!@libs/dropzone"
    ],
    mappings: {
        
    }
};
