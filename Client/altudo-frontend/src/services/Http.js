import axios from 'axios'

const Http = axios.create({
  baseURL: process.env.VUE_APP_API,
  headers: {
    'Access-Control-Allow-Origin': '*'
  },
  crossdomain: true
})

export default Http
