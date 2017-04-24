import * as restify from 'restify';
import { logger } from '../services/logger';
import { settings } from '../config/config';

export default class HealthController {
    public get(req: restify.Request, res: restify.Response, next: restify.Next) {
        logger.info('accessing health route');
        res.json(200, {
            name: settings.name
        });

        return next();
    }
}