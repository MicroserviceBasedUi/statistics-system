import * as restify from 'restify';
import HealthController from '../controllers/healthController'

function sampleRoute(api:restify.Server) {
  let routeController = new HealthController();
  api.get('/api/health', routeController.get);
}

module.exports.routes = sampleRoute;