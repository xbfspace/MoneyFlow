import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app.module';

const platform=platformBrowserDynamic();
platform.bootstrapModule(AppModule)
    .then(success => {
        console.log('应用启动成功');
    })
    .catch(err => {
        console.error('启动应用出错,错误信息：',err);
    });

