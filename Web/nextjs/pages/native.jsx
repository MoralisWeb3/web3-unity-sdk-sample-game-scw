import Moralis from 'moralis';
import { EvmChain } from '@moralisweb3/evm-utils';

function Native({ address, nativeBalance, nftOwners, nfts }) {

    console.log ("address: " + address);
    console.log ("nativeBalance: " + nativeBalance);
    console.log ("nftOwners: " + nftOwners);
    console.log ("nfts: " + nfts);

    return (
        <div>
            <h3>address: {address}</h3>
            <ul>
                <li>nativeBalance: {nativeBalance}</li>
                <li>nftOwners: {nftOwners}</li>
                <li>nfts: {nfts}</li>
            </ul>
        </div>
    );
}

export async function getServerSideProps(context) 
{
    await Moralis.start({ apiKey: process.env.MORALIS_API_KEY });

    const contractAddress = "0x8039b52cE1B54f4700F53100A203E1Fe2E76B4F3";
    const address = '0xe99D6A6427A728Ec2EB57318577bBdc3e43449CD';
 

    var nativeBalance = await Moralis.EvmApi.account.getNativeBalance({
        address: address,
        chain : EvmChain.mumbai,
    });

    var nftOwners = await Moralis.EvmApi.token.getNFTOwners({
        address: address,
        chain : EvmChain.mumbai,
    });

    var nfts = await Moralis.EvmApi.account.getNFTs({
        address: address,
        chain: EvmChain.mumbai
    });
    
    nativeBalance = nativeBalance.result.balance.value.toString(); 
    nftOwners = JSON.stringify(nftOwners.result); 
    nfts = JSON.stringify(nfts.result); 
    
    return {
        props: 
        { 
            address, 
            nativeBalance,
            nftOwners,
            nfts
        },
    };
}

export default Native;