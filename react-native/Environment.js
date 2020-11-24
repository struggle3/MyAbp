const ENV = {
  dev: {
    apiUrl: 'http://localhost:44324',
    oAuthConfig: {
      issuer: 'http://localhost:44324',
      clientId: 'MyAbp_App',
      clientSecret: '1q2w3e*',
      scope: 'MyAbp',
    },
    localization: {
      defaultResourceName: 'MyAbp',
    },
  },
  prod: {
    apiUrl: 'http://localhost:44324',
    oAuthConfig: {
      issuer: 'http://localhost:44324',
      clientId: 'MyAbp_App',
      clientSecret: '1q2w3e*',
      scope: 'MyAbp',
    },
    localization: {
      defaultResourceName: 'MyAbp',
    },
  },
};

export const getEnvVars = () => {
  // eslint-disable-next-line no-undef
  return __DEV__ ? ENV.dev : ENV.prod;
};
