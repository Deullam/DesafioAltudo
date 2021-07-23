import Http from './Http'
const resource = '/page'

export function getPage (item) {
  return Http.post(resource, item)
}

export default {
  getPage
}