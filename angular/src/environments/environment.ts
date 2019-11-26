export const environment = {
  production: false,
  hmr: false,
  application: {
    name: 'AbpSettingManagementMvcUI',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44305',
    clientId: 'AbpSettingManagementMvcUI_App',
    dummyClientSecret: '1q2w3e*',
    scope: 'AbpSettingManagementMvcUI',
    showDebugInformation: true,
    oidc: false,
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44305',
    },
  },
  localization: {
    defaultResourceName: 'AbpSettingManagementMvcUI',
  },
};
