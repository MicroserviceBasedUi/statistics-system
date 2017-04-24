let env = process.env.NODE_ENV || 'development';

export interface Config {
  name: string;
  port: number;
  env: string;
  version: string;
}

export let settings: Config = {
  name: 'restify-typescript-seed',
  version: '2.0.0',
  port: 3000,
  env: 'dev'
};

if (env === 'production') {
  settings.env = 'prod';
  // other production settings
}