import Http from './Http'
const resource = '/page'

export function getPage (item) {
  return Http.post(resource, item)
}
export function getMundo () {
  return Http.get(resource)
}

export default {
  getPage,
  getMundo
}