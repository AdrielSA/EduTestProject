const { defineConfig } = require('@vue/cli-service')
module.exports = defineConfig({
  transpileDependencies: true
})

const fs = require('fs');
const path = require('path');

module.exports = {
  devServer: {
    host: 'localhost',
    port: 8080,
    https: {
      key: fs.readFileSync(path.resolve(__dirname, 'cert\\localhost\\localhost.decrypted.key')),
      cert: fs.readFileSync(path.resolve(__dirname, 'cert\\localhost\\localhostCert.crt')),
      ca: fs.readFileSync(path.resolve(__dirname, 'cert\\localhost\\CA.pem'))
    }
  }
}
