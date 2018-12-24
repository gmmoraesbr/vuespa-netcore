import Axios from 'axios'
import userService from '../services/UserService'

let apiUrl = 'http://localhost:59541/'

// Axios Configuration
Axios.defaults.headers.common.Accept = 'application/json'

export default {
    userService: new userService(Axios, apiUrl)
}