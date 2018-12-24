import Axios from 'axios'
import studentService from '../services/StudentService'
import userService from '../services/UserService'

let apiUrl = 'http://localhost:59541/'

// Axios Configuration
Axios.defaults.headers.common.Accept = 'application/json'

export default {
    studentService: new studentService(Axios, apiUrl),
    userService: new userService(Axios, apiUrl)
}