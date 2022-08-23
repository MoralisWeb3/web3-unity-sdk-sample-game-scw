import { createClient, configureChains, defaultChains, WagmiConfig } from 'wagmi';
import { publicProvider } from 'wagmi/providers/public';
import { SessionProvider } from 'next-auth/react';
import Layout from '../components/layout'

const { provider, webSocketProvider } = configureChains(defaultChains, [publicProvider()]);

const client = createClient({
    provider,
    webSocketProvider,
    autoConnect: true,
});

function MyApp({ Component, pageProps }) {
    return (
        <Layout>
            <WagmiConfig client={client}>
                <SessionProvider session={pageProps.session} refetchInterval={0}>
                    <Component {...pageProps} />
                </SessionProvider>
            </WagmiConfig>
        </Layout>
    );
}

export default MyApp;
